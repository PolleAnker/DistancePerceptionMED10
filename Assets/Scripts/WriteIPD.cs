using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteIPD : MonoBehaviour
{
    public Camera mainCam;
    public bool printIPDStuff = false;
    private Matrix4x4 projectionLeft, projectionRight, viewLeft, viewRight;
    
    private void Update() {
        if(printIPDStuff){
            printIPDStuff = false;
            print("------------Basic Stereo Variables------------");
            print("Stereo enabled? "+mainCam.stereoEnabled + 
                ". Distance between eyes is: "+mainCam.stereoSeparation +
                    ". Eyes converge at: " + mainCam.stereoConvergence);
            print("----------------------------------------------------");

            projectionLeft = mainCam.GetStereoProjectionMatrix(Camera.StereoscopicEye.Left);
            projectionRight = mainCam.GetStereoProjectionMatrix(Camera.StereoscopicEye.Right);
            viewLeft = mainCam.GetStereoViewMatrix(Camera.StereoscopicEye.Left);
            viewLeft = mainCam.GetStereoViewMatrix(Camera.StereoscopicEye.Right);

            print("------------View and Projection Matrices------------");
            print("Left projection matrix is: " + projectionLeft);
            print("Right projection matrix is: " + projectionRight);
            print("----------------------------------------------------");
            print("Left view matrix is: " + viewLeft);
            print("Right view matrix is: " + viewRight);
            print("----------------------------------------------------");
        }
    }
}
