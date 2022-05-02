using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Logging_System;

public class FinalTestManagementBools : MonoBehaviour
{
    public ObjectOpacity opacityScript;
    public LoggingController loggingController;
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

    //public enum targetsEnum {none, Target1, Target2, Target3, Target4, Target5, Target6, Target7, Target8};
    //public enum roomSize{Transitional, Small, Medium, Large};

    [Header("Choose target from the list to activate it :)")]
    public bool TargetNone;
    public bool Target1;
    public bool Target2;
    public bool Target3;
    public bool Target4;
    public bool Target5;
    public bool Target6;
    public bool Target7;
    public bool Target8;
    
    [Header("Choose room from the list to activate it :D")]
    
    public bool TransitionalRoom;
    public bool SmallRoom;
    public bool MediumRoom;
    public bool LargeRoom;

    public GameObject transitionalRoom;
    public GameObject smallRoom;
    public GameObject mediumRoom;
    public GameObject largeRoom;

    [Header("Blind Participant")]
    public bool blindParticipant;

    [Header("Measure Walk")]
    public bool walkedDistance = false;

    void Start()
    {
        loggingController.StartLogging();
    }

    void Update()
    {
        SetTarget();
        SetRoom();

        if(blindParticipant)
        {
            opacityScript.BlindParticipant = blindParticipant;
    
            targetPosition.transform.position = startPosition.position;

            if (targetPosition.activeSelf) 
            {
                targetPosition.SetActive(false);
            }

            TargetNone = true;

            blindParticipant = false;
        }

        if(walkedDistance)
        {
            walkedDistance = false;
            if(targetPosition.activeSelf)
            {
                
                feetPosition.x = playerPosition.position.x;
                feetPosition.y = 0f;
                feetPosition.z = playerPosition.position.z; 
                distanceToTarget = Vector3.Distance(feetPosition, startPosition.transform.position);
                print("The participant walked " + distanceToTarget + " metres");
            }
        }
    }


    /// <summary>
    /// This function sets the room.
    /// </summary>
    public void SetRoom()
    {
        if (TransitionalRoom == true)
        {
            transitionalRoom.SetActive(true);
            smallRoom.SetActive(false);
            mediumRoom.SetActive(false);
            largeRoom.SetActive(false);

            TransitionalRoom = false;
            print("The current room is the Transitional Environment.");
        }

        if(SmallRoom == true)
        {
            smallRoom.SetActive(true);
            transitionalRoom.SetActive(false);
            mediumRoom.SetActive(false);
            largeRoom.SetActive(false);

            SmallRoom = false;
            print("The current room is the Small Room.");
        }

        if(MediumRoom == true)
        {
            mediumRoom.SetActive(true);
            transitionalRoom.SetActive(false);
            smallRoom.SetActive(false);
            largeRoom.SetActive(false);

            MediumRoom = false;
            print("The current room is the Medium Room.");
        }

        if(LargeRoom == true)
        {
            largeRoom.SetActive(true);
            transitionalRoom.SetActive(false);
            smallRoom.SetActive(false);
            mediumRoom.SetActive(false);

            LargeRoom = false;
            print("The current room is the Large Room.");
        }
    }



    /// <summary>
    /// This function has the if-statements for setting and moving the target point in the room.
    /// </summary>
    public void SetTarget()
    {
        if (TargetNone)
        {
            targetPosition.transform.position = startPosition.position;
            targetPosition.SetActive(false);

            TargetNone = false;
            print("There is no current target.");
        }

        if(Target1)
        {
            targetPosition.transform.position = startPosition.position + distance1;
            targetPosition.SetActive(true);

            Target1 = false;
            print("The current target is Target 1.");
        }

        if(Target2)
        {
            targetPosition.transform.position = startPosition.position + distance2;
            targetPosition.SetActive(true);

           Target2 = false;
           print("The current target is Target 2.");
        }

        if(Target3)
        {
            targetPosition.transform.position = startPosition.position + distance3;
            targetPosition.SetActive(true);

            Target3 = false;
            print("The current target is Target 3.");
        }

        if(Target4)
        {
            targetPosition.transform.position = startPosition.position + distance4;
            targetPosition.SetActive(true);

            Target4 = false;
            print("The current target is Target 4.");
        }

        if(Target5)
        {
            targetPosition.transform.position = startPosition.position + distance5;
            targetPosition.SetActive(true);

            Target5 = false;
            print("The current target is Target 5.");
        }

        if(Target6)
        {
            targetPosition.transform.position = startPosition.position + distance6;
            targetPosition.SetActive(true);

            Target6 = false;
            print("The current target is Target 6.");
        }

        if(Target7)
        {
            targetPosition.transform.position = startPosition.position + distance7;
            targetPosition.SetActive(true);

            Target7 = false;
            print("The current target is Target 7.");
        }

        if(Target8)
        {
            targetPosition.transform.position = startPosition.position + distance8;
            targetPosition.SetActive(true);

            Target8 = false;
            print("The current target is Target 8.");
        }
    }
}
