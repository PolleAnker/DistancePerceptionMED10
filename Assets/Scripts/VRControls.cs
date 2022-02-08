using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRControls : MonoBehaviour
{
    public ActionBasedController leftController;
    public ActionBasedController rightController;

    [Header("Reference to the object resizer gameobject")]
    public ObjectResizer objectResizer;
    private Transform resizeTarget;
    
    [Header("Percent of base scale to add")]
    public float scalePerClick = 0.01f;
    
    // Weird new input system must-haves, don't ask
    void OnEnable()
    {
        leftController.activateAction.action.Enable();
        rightController.activateAction.action.Enable();
    }
    void OnDisable()
    {
        leftController.activateAction.action.Disable();
        rightController.activateAction.action.Disable();
    }

    void Awake()
    {
        resizeTarget = objectResizer.objectToResize.transform;
    }

    void Update()
    {
        resizeTarget = objectResizer.objectToResize.transform;
        if(leftController.activateActionValue.action.ReadValue<float>() > 0.1){
            //Debug.Log("Left trigger pressed");
            if(resizeTarget.localScale.magnitude >= (Vector3.one * 0.5f).magnitude){
                resizeTarget.localScale -= (Vector3.one * scalePerClick);
            }
        }
        if(rightController.activateActionValue.action.ReadValue<float>() > 0.1){
            //Debug.Log("Right trigger pressed");
            if(resizeTarget.localScale.magnitude <= (Vector3.one * 2.5f).magnitude){
            resizeTarget.localScale += (Vector3.one * scalePerClick);
            }
        }
    }
}
