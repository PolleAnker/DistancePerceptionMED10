using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireScaler : MonoBehaviour
{
    [Header("Start tower settings (spawns under participant)")]
    public GameObject startTowerPrefab;
    private GameObject startPoint;
    public bool spawnStartTower = false;

    [Header("Reference to the grabbable tower wire connector object")]
    public Transform endTower;

    [Header("References for spawning target point")]
    [Range(-1.9f,1.9f)]public float xCoord = 0f;    // Based on the roomsize    (AVA lab is -3.2f,3.2f)
    [Range(-1.9f,1.9f)]public float zCoord = 0f;    // Based on the roomsize    (AVA lab is -2.6f,2.5f)
    private float yCoord = 0f;  // Don't touch, it's grounded
    public GameObject targetIndicator;
    public bool setTarget = false;
    public bool removeTarget = false;
    private GameObject activeTarget;

    ////
    private Vector3 initialScale;
    private float distBetweenPoints;

    [Header("Press to print distance from start point (tower) to target point")]
    public bool printDistance = false;
    private float distanceFromStartToTarget;    // Print this to get distance from start point to target point
    ////

    [Header("Reference to XR Rig camera")]
    public Transform mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
        //print("Scaling object in start method");
        if(startPoint){
            RescaleObject();
        }
    }
    void Awake()
    {
        startPoint = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnStartTower){
            spawnStartTower = false;
            SpawnStartTower();
        }
        
        if(startPoint != null){
            // Only do rescaling if either of the two points to scale between has changed
            if(startPoint.transform.hasChanged || endTower.transform.hasChanged)
            {
                //print("Rescaling object");
                RescaleObject();
            }
        }

        /// Call for function spawning a target point
        if(setTarget){
            setTarget = false;
            SpawnTargetPoint();
        }

        /// Code for removing a spawned target indicator
        if(removeTarget){
            removeTarget = false;
            if(activeTarget){
                Destroy(activeTarget);
            }
        }

        if(printDistance && (startPoint && activeTarget)){
            printDistance = false;
            Vector3 targetPos = new Vector3(activeTarget.transform.position.x, 0, activeTarget.transform.position.z);
            Vector3 startPos = new Vector3(startPoint.transform.position.x, 0, startPoint.transform.position.z);
            distanceFromStartToTarget = Vector3.Distance(targetPos, startPos);
            print("Distance from start point to target point is " + distanceFromStartToTarget + " meters");
        }
    }

    private void RescaleObject()
    {
        // Calculate the scale of the object
        distBetweenPoints = Vector3.Distance(startPoint.transform.position, endTower.position);
        transform.localScale = new Vector3(initialScale.x, distBetweenPoints/2f, initialScale.z);   // Division by 2 for a cylinder object

        // Calculate the position to place this object at
        Vector3 middlePoint = (startPoint.transform.position + endTower.position) / 2;    // find middle between the two points (where to put this object)
        transform.position = middlePoint;

        // Calculate how to rotate / where to face this object
        Vector3 rotationDirection = (endTower.position - startPoint.transform.position);
        transform.up = rotationDirection;
    }
    private void SpawnStartTower(){
        if(!startPoint){
            Vector3 spawnPosition = new Vector3(mainCamera.position.x, 0.325f, mainCamera.position.z);
            startPoint = Instantiate(startTowerPrefab, spawnPosition, Quaternion.identity);
        }
        else{
            Vector3 spawnPosition = new Vector3(mainCamera.position.x, 0.325f, mainCamera.position.z);
            startPoint.transform.position = spawnPosition;
        }
    }
    private void SpawnTargetPoint(){
        //Debug.Log("Spawning an object");
        if(!activeTarget){
            //Debug.Log("Spawning object");
            activeTarget = Instantiate(targetIndicator, new Vector3(xCoord, yCoord, zCoord), Quaternion.identity);
            activeTarget.transform.eulerAngles = new Vector3(90f, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        else{
            //Debug.Log("Moving object");
            activeTarget.transform.position = new Vector3(xCoord, yCoord, zCoord);
            activeTarget.transform.eulerAngles = new Vector3(90f, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}
