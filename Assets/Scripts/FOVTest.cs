using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class FOVTest : MonoBehaviour
{
    [Header("XR Variables")]
    public ActionBasedController leftController;
    public ActionBasedController rightController;
    public Camera cam;

    [Header("FOV Elements")]
    public RectTransform leftLine;
    public RectTransform rightLine;
    public RectTransform topLine;
    public RectTransform bottomLine;
    public TextMeshProUGUI fovAngleText;

    [Header("Test Variables")]
    public bool vertical = false;
    public bool horizontal = false;
    public bool updateAngle = false;
    private float fovAngle;
    private Vector3 side1 = Vector3.zero;
    private Vector3 side2 = Vector3.zero;

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

    void Update()
    {
        if(horizontal){
            vertical = false;
            if(updateAngle){
                side1 = leftLine.transform.position - cam.transform.position;
                side2 = rightLine.transform.position - cam.transform.position;
                fovAngle = Vector3.Angle(side1, side2);
                fovAngle = (float)Math.Round(fovAngle, 2);
                fovAngleText.text = ""+fovAngle;
            }
        }
        if(vertical){
            horizontal = false;
            if(updateAngle){
                side1 = topLine.transform.position - cam.transform.position;
                side2 = bottomLine.transform.position - cam.transform.position;
                fovAngle = Vector3.Angle(side1, side2);
                fovAngle = (float)Math.Round(fovAngle, 2);
                fovAngleText.text = ""+fovAngle;
            }
        }

        if (leftController.activateActionValue.action.ReadValue<float>() > 0.1f)
        {
            if(horizontal){
                leftLine.localPosition += new Vector3(-1,0,0);
                rightLine.localPosition += new Vector3(1,0,0);
            }
            if(vertical){
                topLine.localPosition += new Vector3(0,1,0);
                bottomLine.localPosition += new Vector3(0,-1,0);
            }

        }
        if (rightController.activateActionValue.action.ReadValue<float>() > 0.1)
        { 
            if(horizontal){
                leftLine.localPosition += new Vector3(1,0,0);
                rightLine.localPosition += new Vector3(-1,0,0);
            }
            if(vertical){
                topLine.localPosition += new Vector3(0,-1,0);
                bottomLine.localPosition += new Vector3(0,1,0);
            }

        }
    }
}
