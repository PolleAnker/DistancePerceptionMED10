using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireScaler : MonoBehaviour
{
    public GameObject startTowerPrefab;
    private GameObject startPoint;
    public bool spawnStartTower = false;
    public Transform endPoint;
    private Vector3 initialScale;
    private float distBetweenPoints;
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
            if(startPoint.transform.hasChanged || endPoint.transform.hasChanged)
            {
                //print("Rescaling object");
                RescaleObject();
            }
        }
    }

    private void RescaleObject()
    {
        // Calculate the scale of the object
        distBetweenPoints = Vector3.Distance(startPoint.transform.position, endPoint.position);
        transform.localScale = new Vector3(initialScale.x, distBetweenPoints/2f, initialScale.z);   // Division by 2 for a cylinder object

        // Calculate the position to place this object at
        Vector3 middlePoint = (startPoint.transform.position + endPoint.position) / 2;    // find middle between the two points (where to put this object)
        transform.position = middlePoint;

        // Calculate how to rotate / where to face this object
        Vector3 rotationDirection = (endPoint.position - startPoint.transform.position);
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
}
