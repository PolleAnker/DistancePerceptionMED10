using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class IPDTest : MonoBehaviour
{
    [Header("XR Variables")]
    public ActionBasedController leftController;
    public ActionBasedController rightController;
    public Canvas uiCanvas;
    private Camera cam;

    [Header("FOV Elements")]
    public RectTransform left;
    public RectTransform right;
    public TextMeshProUGUI IPDText;

    [Header("Test Variables")]
    public bool moveLeft = false;
    public bool moveRight = false;
    private float IPDDistanceTemp = 0f;

    private void Awake() {
        cam = Camera.main;
        uiCanvas.worldCamera = cam;
    }

    void OnEnable()
    {
        // Deal with Trigger input activations
        leftController.activateAction.action.Enable();
        rightController.activateAction.action.Enable();
        
        // Deal with Grip input activations
        leftController.selectAction.action.Enable();
        rightController.selectAction.action.Enable();
    }
    void OnDisable()
    {
        // Deal with Trigger input activations
        leftController.activateAction.action.Disable();
        rightController.activateAction.action.Disable();

        // Deal with Grip input activations
        leftController.selectAction.action.Disable();
        rightController.selectAction.action.Disable();
    }

    void Update()
    {
        if(moveRight){
            moveLeft = false;
            IPDDistanceTemp = Vector3.Distance(left.localPosition, right.localPosition);
            IPDText.text = ""+IPDDistanceTemp;
        }
        if(moveLeft){
            moveRight = false;
            IPDDistanceTemp = Vector3.Distance(left.localPosition, right.localPosition);
            IPDText.text = ""+IPDDistanceTemp;
        }

        if (leftController.activateActionValue.action.ReadValue<float>() > 0.1f)
        {
            // Move horizontal indicators apart if left trigger is pressed
            if(moveRight){
                right.localPosition += new Vector3(-1,0,0);
            }
            // Move top line up if left trigger is pressed
            if(moveLeft){
                left.localPosition += new Vector3(-1,0,0);
            }

        }
        if (rightController.activateActionValue.action.ReadValue<float>() > 0.1f)
        { 
            // Move horizontal indicators closer if right trigger is pressed
            if(moveRight){
                right.localPosition += new Vector3(1,0,0);
            }
            // Move bottom line up if right trigger is pressed
            if(moveLeft){
                left.localPosition += new Vector3(1,0,0);
            }
        }
    }
}

