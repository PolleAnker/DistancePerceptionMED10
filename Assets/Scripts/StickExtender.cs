using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StickExtender : MonoBehaviour
{
    public GameObject stickToResize;
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

    void Start()
    {
        resizeTarget = objectResizer.objectToResize.transform;
    }

    // Update is called once per frame
    void Update()
    {
        resizeTarget = objectResizer.objectToResize.transform;
        if (leftController.activateActionValue.action.ReadValue<float>() > 0.1)
        {
            //Debug.Log("Left trigger pressed");
            if (resizeTarget.localScale.magnitude >= (Vector3.one * 0.5f).magnitude)
            {
                resizeTarget.localScale -= baseScale + Vector3(0, 0, scalePerClick);
            }
        }
        if (rightController.activateActionValue.action.ReadValue<float>() > 0.1)
        {
            Vector3 baseScale = new Vector3(transform.localScale.x, transform.localScale.y, 0);
           
            //Debug.Log("Right trigger pressed");
            if (resizeTarget.localScale.magnitude <= (Vector3.one * 2.5f).magnitude)
            {
                resizeTarget.localScale += baseScale + Vector3(0, 0, scalePerClick);
            }
        }
}
