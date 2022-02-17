using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRControls : MonoBehaviour
{
    public ActionBasedController leftController;
    public ActionBasedController rightController;

    [Header("Object Resizing variables")]
    public bool resizingEnabled = false;
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
        if(resizingEnabled) resizeTarget = objectResizer.objectToResize.transform;
    }

    void Update()
    {
        if(resizingEnabled){
            resizeTarget = objectResizer.objectToResize.transform;
            if(leftController.activateActionValue.action.ReadValue<float>() > 0.1){
                //Debug.Log("Left trigger pressed");
                if(resizeTarget.localScale.magnitude >= (Vector3.one * 0.5f).magnitude){
                    resizeTarget.localScale -= (Vector3.one * scalePerClick);
                }
            }
            if(rightController.activateActionValue.action.ReadValue<float>() > 0.1){
                //Debug.Log("Right trigger pressed");
                Vector3 baseScale = new Vector3(transform.localScale.x, 0, transform.localScale.z);
                if(resizeTarget.localScale.magnitude <= (Vector3.one * 2.5f).magnitude){
                //resizeTarget.localScale += (Vector3.one * scalePerClick);
                resizeTarget.localScale = baseScale + new Vector3(0, scalePerClick, 0);
                }
            }
        }
    }
}
