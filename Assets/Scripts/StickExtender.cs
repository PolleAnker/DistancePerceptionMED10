using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StickExtender : MonoBehaviour
{
    public Transform stickToResize;
    public bool resetScale = false;

    public ActionBasedController leftController;
    public ActionBasedController rightController;

    public ObjectResizer objectResizer;

    [Header("Percent of base scale to add")]
    public float scalePerClick = 0.001f;

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

    // Update is called once per frame
    void Update()
    {
        //stickToResize = objectResizer.objectToResize.transform;
        if (leftController.activateActionValue.action.ReadValue<float>() > 0.1f)
        {
            //Debug.Log("Left trigger pressed");
            if (stickToResize.localScale.magnitude >= 0.7f) //set to minimum length of the small stick to 70cm ish
            {
                stickToResize.localScale -= new Vector3(0, scalePerClick, 0);
            }
        }
        if (rightController.activateActionValue.action.ReadValue<float>() > 0.1)
        { 
            //Debug.Log("Right trigger pressed");
            if (stickToResize.localScale.magnitude <= 1.23f) //set to the maximum length of the small stich to 123cm ish 
            {
                stickToResize.localScale += new Vector3(0, scalePerClick, 0);
            }
        }
    }
}
