using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TelescopicFunctionalities : MonoBehaviour
{
    public ActionBasedController rightController;
    public ActionBasedController leftController;

    public GameObject[] rodMetals;
    public GameObject rodStart;
    public GameObject rodEnd;

    private float rodYPos;
    private float newRodYPos;
    private float[] rodYStartPos = new float [19]; //Add extras if extra metal pieces are added to the rod
    private int rodArrayMax = 18;
    private float childPos;


    [Header("Reset Rod")]
    public bool resetRod = false;

    [Header("Increase Rod (can be controlled in VR as well)")]
    public bool increaseRod = false;

    [Header("Decrease Rod (can be controlled in VR as well)")]
    public bool decreaseRod = false;

    [Header("Print Rod Length")]
    public bool printRodLength = false;
    private float rodLength = 0f;

    void Start() 
    {
        rodYStartPos[0] = rodMetals[0].transform.localPosition.y;

    }

    void OnEnable()
    {
        rightController.activateAction.action.Enable();
        leftController.activateAction.action.Enable();
    }
    void OnDisable()
    {
        rightController.activateAction.action.Disable();
        leftController.activateAction.action.Disable();
    }

    // Update is called once per frame
    void Update()
    {
         if (rightController.activateActionValue.action.ReadValue<float>() > 0.1)
        { 
            increaseRod = true;
        }

        if (leftController.activateActionValue.action.ReadValue<float>() > 0.1f)
        {
            decreaseRod = true;
        }
        
        if(resetRod)
        {
            resetRod = false;
            for(int i = 1; i < rodMetals.Length; i++) //set all metal pieces back to their original position
            {
                rodMetals[0].transform.localPosition = new Vector3(rodMetals[0].transform.localPosition.x, rodYStartPos[0], rodMetals[0].transform.localPosition.z); //resetting the first metal piece as it is not included in the for-loop

                rodYPos = rodMetals[i].transform.localPosition.y; 
                if(rodYPos <=  rodMetals[i-1].transform.localPosition.y)
                {
                    childPos = rodMetals[i-1].transform.localPosition.y - 0.001f;
                    rodMetals[i].transform.localPosition = new Vector3(rodMetals[i].transform.localPosition.x, childPos, rodMetals[i].transform.localPosition.z);
                }
            }
        }

        if(increaseRod) //if buttonpress (needs to be changed to the quest grip-thingy)
        {
            increaseRod = false;

            for(int i = 0; i < rodMetals.Length; i++)
            {
                rodYPos = rodMetals[i].transform.localPosition.y; 

                if(rodYPos > rodYStartPos[i] - 0.10f) //if the current metal piece's position is NOT moved 10cm since the starting point
                {
                    newRodYPos = rodMetals[i].transform.localPosition.y - 0.001f; // find new position with increased length of 1cm

                    //print("#Increase# This is piece number " + (i+1) + " with position " + rodMetals[i].transform.localPosition.y);
                    print("Metal Piece Number: " + (i+1));
                    print("Starting Position: " + rodYStartPos[i]);
                    print("Current Position: " + newRodYPos);

                    rodMetals[i].transform.localPosition = new Vector3(rodMetals[i].transform.localPosition.x, newRodYPos, rodMetals[i].transform.localPosition.z); // increase length with 1cm

                    break; //breaks from the for-loop
                }
                else
                {
                    if(i < rodArrayMax)
                    {
                        rodYStartPos[i+1] = rodMetals[i].transform.localPosition.y; //setting the starting point for the next metal piece to be moved
                    }
                }
            }

            for(int i = 1; i < rodMetals.Length; i++) //check if any "fake parent" metal piece have moved and make the "fake child" follow
            {
                rodYPos = rodMetals[i].transform.localPosition.y; 
                if(rodYPos >=  rodMetals[i-1].transform.localPosition.y)
                {
                    childPos = rodMetals[i-1].transform.localPosition.y - 0.001f;
                    rodMetals[i].transform.localPosition = new Vector3(rodMetals[i].transform.localPosition.x, childPos, rodMetals[i].transform.localPosition.z);
                }
            }
        }

        if(decreaseRod) //if buttonpress (needs to be changed to the quest grip-thingy)
        {
            decreaseRod = false;

            for (int j = rodMetals.Length; j --> 0; )
            {
                rodYPos = rodMetals[j].transform.localPosition.y; 
                
                if(j > 0)
                {
                    if(rodYPos < rodMetals[j-1].transform.localPosition.y - 0.002) //if the current metal piece's position is not back to its starting point
                    {
                        newRodYPos = rodMetals[j].transform.localPosition.y + 0.001f; // find new position with decreased length of 1cm

                        rodMetals[j].transform.localPosition = new Vector3(rodMetals[j].transform.localPosition.x, newRodYPos, rodMetals[j].transform.localPosition.z); // decrease length with 1cm

                        for(int i = j+1; i < rodMetals.Length; i++) //check if any "fake parent" metal piece have moved and make the "fake child" follow
                        {
                            rodYPos = rodMetals[i].transform.localPosition.y; 

                            if(rodYPos < rodMetals[i-1].transform.localPosition.y - 0.002)
                            {
                            childPos = rodMetals[i-1].transform.localPosition.y - 0.001f;
                                rodMetals[i].transform.localPosition = new Vector3(rodMetals[i].transform.localPosition.x, childPos, rodMetals[i].transform.localPosition.z);
                            }
                        }

                        break; //breaks from the for-loop
                    }
                }
                else if(rodYPos < rodYStartPos[0])
                {
                    newRodYPos = rodMetals[j].transform.localPosition.y + 0.01f; // find new position with decreased length of 1cm

                    rodMetals[j].transform.localPosition = new Vector3(rodMetals[j].transform.localPosition.x, newRodYPos, rodMetals[j].transform.localPosition.z); // decrease length with 1cm

                    if(rodYPos > rodYStartPos[0])
                    {
                        rodMetals[j].transform.localPosition = new Vector3(rodMetals[j].transform.localPosition.x, rodYStartPos[0], rodMetals[j].transform.localPosition.z);
                    }

                    for(int i = j+1; i < rodMetals.Length; i++) //check if any "fake parent" metal piece have moved and make the "fake child" follow
                    {
                        rodYPos = rodMetals[i].transform.localPosition.y; 

                        if(rodYPos < rodMetals[i-1].transform.localPosition.y - 0.002)
                        {
                        childPos = rodMetals[i-1].transform.localPosition.y - 0.001f;
                            rodMetals[i].transform.localPosition = new Vector3(rodMetals[i].transform.localPosition.x, childPos, rodMetals[i].transform.localPosition.z);
                        }
                    }

                    break; //breaks from the for-loop
                }
                
            }
        }

         if(printRodLength)
        {
            printRodLength = false;

            rodLength = Vector3.Distance(rodStart.transform.position, rodEnd.transform.position);
            print("Rod Length = " + rodLength);
        }
    }
}
