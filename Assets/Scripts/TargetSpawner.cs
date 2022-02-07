using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetObject;
    private GameObject activeTarget;
    public Transform playerPosition;
    private Vector3 feetPosition;

    [Header("Settings for target position")]
    [Range(-3.2f,3.2f)]public float xCoord = 0f;    // Based on the roomsize
    [Range(-2.6f,2.5f)]public float zCoord = 0f;    // Based on the roomsize
    private float yCoord = 0f;  // Don't touch, it's grounded

    [Header("Press this to spawn or move target")]
    public bool setTarget = false;
    
    [Header("Press this to print the distance from the player to the target")]
    public bool distance = false;
    private float distanceToTarget = 0f;
    
    [Header("Press this to delete the target")]
    public bool removeTarget = false;

    // Update is called once per frame
    void Update()
    {
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
    }
}
