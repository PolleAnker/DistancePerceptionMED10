using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelescopicFunctionalities : MonoBehaviour
{
     //public ActionBasedController leftController;
    //public ActionBasedController rightController;

    public GameObject[] rodMetals;
    public GameObject rodStart;
    public GameObject rodEnd;

    private float rodYPos;
    private float newRodYPos;
    private float[] rodYStartPos = new float [6]; //Add extras if extra metal pieces are added to the rod

    [Header("Reset Rod")]
    public bool resetRod = false;

    [Header("Increase Rod")]
    public bool increaseRod = false;

    [Header("Decrease Rod")]
    public bool decreaseRod = false;

    [Header("Print Rod Length")]
    public bool printRodLength = false;
    private float rodLength = 0f;

    void Start() 
    {
        rodYStartPos[0] = rodMetals[0].transform.localPosition.y;
        rodYStartPos[1] = rodMetals[1].transform.localPosition.y;
        rodYStartPos[2] = rodMetals[2].transform.localPosition.y;
        rodYStartPos[3] = rodMetals[3].transform.localPosition.y;
        rodYStartPos[4] = rodMetals[4].transform.localPosition.y;
        rodYStartPos[5] = rodMetals[5].transform.localPosition.y;

    }

    void OnEnable()
    {
        //leftController.activateAction.action.Enable();
        //rightController.activateAction.action.Enable();
    }
    void OnDisable()
    {
        //leftController.activateAction.action.Disable();
        //rightController.activateAction.action.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if(resetRod)
        {
            resetRod = false;
            
            for(int i = 0; i < rodMetals.Length; i++)
            {
                rodMetals[i].transform.localPosition = new Vector3(rodMetals[i].transform.localPosition.x, rodYStartPos[i], rodMetals[i].transform.localPosition.z);
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
                    newRodYPos = rodMetals[i].transform.localPosition.y - 0.01f; // find new position with increased length of 1cm

                    print("This is piece number " + i + " with position " + rodMetals[i].transform.localPosition.y);

                    rodMetals[i].transform.localPosition = new Vector3(rodMetals[i].transform.localPosition.x, newRodYPos, rodMetals[i].transform.localPosition.z); // increase length with 1cm

                    break;
                }
            }
        }

        if(decreaseRod) //if buttonpress (needs to be changed to the quest grip-thingy)
        {
            decreaseRod = false;
            //Move the rod latest rod metal back until minimum length
            //Then move next and so on....
        }

         if(printRodLength)
        {
            printRodLength = false;

            rodLength = Vector3.Distance(rodStart.transform.position, rodEnd.transform.position);
            print("Rod Length = " + rodLength);
        }
    }
}
