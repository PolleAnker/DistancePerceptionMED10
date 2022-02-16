using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject startPointObject;
    private GameObject activeTarget;
    private GameObject activeStartPoint;
    public Transform playerPosition;
    private Vector3 feetPosition;

    [Header("Settings for target position")]
    [Range(-1.9f,1.9f)]public float xCoord = 0f;    // Based on the roomsize    (AVA lab is -3.2f,3.2f)
    [Range(-1.9f,1.9f)]public float zCoord = 0f;    // Based on the roomsize    (AVA lab is -2.6f,2.5f)
    private float yCoord = 0f;  // Don't touch, it's grounded

    [Header("Press this to spawn or move target")]
    public bool setTarget = false;
    
    [Header("Press this to print the distance from the player to the target")]
    public bool distance = false;
    private float distanceToTarget = 0f;
    
    [Header("Press this to delete the target")]
    public bool removeTarget = false;

    [Header("Use these to spawn and remove the start point")]
    public bool setStartPoint = false;
    public bool removeStartPoint = false;

    // Update is called once per frame
    void Update()
    {

        /// Functionality for setting and removing a target position
        if(setTarget){
            setTarget = false;
            //Debug.Log("Spawning an object");
            if(!activeTarget){
                //Debug.Log("Spawning object");
                activeTarget = Instantiate(targetObject, new Vector3(xCoord, yCoord, zCoord), Quaternion.identity);
                activeTarget.transform.eulerAngles = new Vector3(90f, transform.eulerAngles.y, transform.eulerAngles.z);
            }
            else{
                //Debug.Log("Moving object");
                activeTarget.transform.position = new Vector3(xCoord, yCoord, zCoord);
                activeTarget.transform.eulerAngles = new Vector3(90f, transform.eulerAngles.y, transform.eulerAngles.z);
            }
        }
        if(removeTarget){
            removeTarget = false;
            if(activeTarget){
                Destroy(activeTarget);
            }
        }
        ///

        /// Functionality for calculating + printing the distance from a participant to the target point
        if(distance){
            distance = false;
            if(activeTarget){
                feetPosition.x = playerPosition.position.x;
                feetPosition.y = 0f;
                feetPosition.z = playerPosition.position.z; 
                distanceToTarget = Vector3.Distance(feetPosition, activeTarget.transform.position);
                print("The distance between target and player is " + distanceToTarget + " meters");
            }
        }
        ///

        /// Functionality for spawning and deleting start points
        if(setStartPoint){
            setStartPoint = false;
            if(!activeStartPoint){
                //activeStartPoint = Instantiate(startPointObject, new Vector3(0,0,0), Quaternion.identity);
                /// Use this if we want to spawn start point under the participant
                activeStartPoint = Instantiate(startPointObject, new Vector3(playerPosition.position.x, 0f, playerPosition.position.z), Quaternion.identity);   
            }
            else{
                // activeStartPoint.transform.position = new Vector3(0,0,0);
                activeStartPoint.transform.position = new Vector3(playerPosition.position.x, 0f, playerPosition.position.z);
            }

            // Rotate object to face up
            activeStartPoint.transform.eulerAngles = new Vector3(90f, transform.eulerAngles.y, transform.eulerAngles.z);
            
        }
        if(removeStartPoint){
            removeStartPoint = false;
            if(activeStartPoint){
                Destroy(activeStartPoint);
            }
        }
        ///
    }
}
