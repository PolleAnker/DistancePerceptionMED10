using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class FOVTest2 : MonoBehaviour
{
    [Header("XR Variables")]
    public Camera cam;

    [Header("FOV Elements")]
    public RectTransform centreLine;
    public RectTransform farRight;
    public RectTransform farLeft;
    public TextMeshProUGUI fovAngleText;

    [Header("Test Variables")]
    public bool leftFOV = false;
    public bool rightFOV = false;
    public bool updateAngle = false;
    private float fovAngle;
    private Vector3 side1 = Vector3.zero;
    private Vector3 side2 = Vector3.zero;

    void Update()
    {
        if(leftFOV){
            rightFOV = false;
            if(updateAngle){
                side1 = farLeft.transform.position - cam.transform.position;
                side2 = centreLine.transform.position - cam.transform.position;
                fovAngle = Vector3.Angle(side1, side2);
                fovAngle = (float)Math.Round(fovAngle, 2);
                fovAngleText.text = ""+fovAngle;
            }
        }
        if(rightFOV){
            leftFOV = false;
            if(updateAngle){
                side1 = farRight.transform.position - cam.transform.position;
                side2 = centreLine.transform.position - cam.transform.position;
                fovAngle = Vector3.Angle(side1, side2);
                fovAngle = (float)Math.Round(fovAngle, 2);
                fovAngleText.text = ""+fovAngle;
            }
        }
    }
}
