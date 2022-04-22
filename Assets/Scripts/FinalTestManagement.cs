using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTestManagement : MonoBehaviour
{
    public ObjectOpacity opacityScript;
    public GameObject targetPosition;
    public Transform startPosition;
    public Transform playerPosition;
    private Vector3 feetPosition;
    private float distanceToTarget = 0f;

    private Vector3 distance1 = new Vector3 (-0.54f, 0f, -0.72f);
    private Vector3 distance2 = new Vector3 (0.72f, 0f, -1.54f);
    private Vector3 distance3 = new Vector3 (-1f, 0f, -2.4f);
    private Vector3 distance4 = new Vector3 (0f, 0f, -3.2f);
    private Vector3 distance5 = new Vector3 (1.8f, 0f, -4.45f);
    private Vector3 distance6 = new Vector3 (0f, 0f, -5.8f);
    private Vector3 distance7 = new Vector3 (-3.01f, 0f, -6.43f);
    private Vector3 distance8 = new Vector3 (0f, 0f, -10.8f);

    public enum targetsEnum {none, Target1, Target2, Target3, Target4, Target5, Target6, Target7, Target8};

    [Header("Choose target from the list to activate it :)")]
    public targetsEnum target;

    [Header("Blind Participant")]
    public bool blindParticipant;

    [Header("Measure Walk")]
    public bool walkedDistance = false;

    void Update()
    {
        if (target == targetsEnum.none)
        {
            targetPosition.transform.position = startPosition.position;
            targetPosition.SetActive(false);
        }

        if(target == targetsEnum.Target1)
        {
            targetPosition.transform.position = startPosition.position + distance1;
            targetPosition.SetActive(true);
        }

        if(target == targetsEnum.Target2)
        {
            targetPosition.transform.position = startPosition.position + distance2;
            targetPosition.SetActive(true);
        }

        if(target == targetsEnum.Target3)
        {
            targetPosition.transform.position = startPosition.position + distance3;
            targetPosition.SetActive(true);
        }

        if(target == targetsEnum.Target4)
        {
            targetPosition.transform.position = startPosition.position + distance4;
            targetPosition.SetActive(true);
        }

        if(target == targetsEnum.Target5)
        {
            targetPosition.transform.position = startPosition.position + distance5;
            targetPosition.SetActive(true);
        }

        if(target == targetsEnum.Target6)
        {
            targetPosition.transform.position = startPosition.position + distance6;
            targetPosition.SetActive(true);
        }

        if(target == targetsEnum.Target7)
        {
            targetPosition.transform.position = startPosition.position + distance7;
            targetPosition.SetActive(true);
        }

        if(target == targetsEnum.Target8)
        {
            targetPosition.transform.position = startPosition.position + distance8;
            targetPosition.SetActive(true);
        }

        if(blindParticipant){
            opacityScript.BlindParticipant = blindParticipant;
    
            targetPosition.transform.position = startPosition.position;

            if (targetPosition.activeSelf) 
            {
                targetPosition.SetActive(false);
            }

            target = targetsEnum.none;

            blindParticipant = false;
        }

        if(walkedDistance){
            walkedDistance = false;
            if(targetPosition.activeSelf){
                
                feetPosition.x = playerPosition.position.x;
                feetPosition.y = 0f;
                feetPosition.z = playerPosition.position.z; 
                distanceToTarget = Vector3.Distance(feetPosition, startPosition.transform.position);
                print("The participant walked " + distanceToTarget + " metres");
            }
        }
    }
}
