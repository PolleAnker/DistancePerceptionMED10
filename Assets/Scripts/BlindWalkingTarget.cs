using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindWalkingTarget : MonoBehaviour
{
    public GameObject target;
    public Transform startPosition;
    public Transform playerPosition;
    private Vector3 feetPosition;
    private float distanceToTarget = 0f;

    private Vector3 distance1 = new Vector3 (-0.35f, 0, -1.2f);
    private Vector3 distance2 = new Vector3 (0.75f, 0, -1.8f);
    private Vector3 distance3 = new Vector3 (-2.68f, 0, -3.8f);
    private Vector3 distance4 = new Vector3 (2.88f, 0, -7.41f);
    private Vector3 distance5 = new Vector3 (0f, 0, -10.35f);
    

    [Header("Measure Walk")]
    public bool walkedDistance = false;

    [Header("Measure Distance")]
    public bool targetDistance = false;

    [Header("Press Target to activate it")]
    public bool Target1 = false;
    public bool Target2 = false;
    public bool Target3 = false;
    public bool Target4 = false;
    public bool Target5 = false;

    [Header("REMOVE TARGET BEFORE GIVING THE PARTICIPANT THEIR VISION BACK")]
    public bool removeTarget = false;

    // Start is called before the first frame update
    void Start()
    {
        target.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Target1){
            target.transform.position = startPosition.position + distance1;
            target.SetActive(true);
            Target2 = false;
            Target3 = false;
            Target4 = false;
            Target5 = false;
        }

        if(Target2){
            target.transform.position = startPosition.position + distance2;
            target.SetActive(true);
            Target1 = false;
            Target3 = false;
            Target4 = false;
            Target5 = false;
        }

        if(Target3){
            target.transform.position = startPosition.position + distance3;
            target.SetActive(true);
            Target1 = false;
            Target2 = false;
            Target4 = false;
            Target5 = false;
        }

        if(Target4){
            target.transform.position = startPosition.position + distance4;
            target.SetActive(true);
            Target1 = false;
            Target2 = false;
            Target3 = false;
            Target5 = false;
        }

        if(Target5){
            target.transform.position = startPosition.position + distance5;
            target.SetActive(true);
            Target1 = false;
            Target2 = false;
            Target3 = false;
            Target4 = false;
        }


        if(removeTarget){
            removeTarget = false;
            target.transform.position = startPosition.position;
            target.SetActive(false);
            Target1 = false;
            Target2 = false;
            Target3 = false;
            Target4 = false;
            Target5 = false;
        }

        if(walkedDistance){
            walkedDistance = false;
            if(target.activeSelf){
                feetPosition.x = playerPosition.position.x;
                feetPosition.y = 0f;
                feetPosition.z = playerPosition.position.z; 
                distanceToTarget = Vector3.Distance(feetPosition, target.transform.position);
                print("The participant walked " + distanceToTarget + " metres");
            }
        }

        if(targetDistance){
            targetDistance = false;
            if(target.activeSelf){
                distanceToTarget = Vector3.Distance(startPosition.position, target.transform.position);
                print("The distance from the start to the target was " + distanceToTarget + " metres");
            }
        }
    }
}
