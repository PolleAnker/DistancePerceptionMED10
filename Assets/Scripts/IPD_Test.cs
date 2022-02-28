using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
 

public class IPD_Test : MonoBehaviour
{
    [Range(-10.0f, 10.0f)]
    public float X_Axis;
    [SerializeField]
    private Vector3 distance = new Vector3(0, 1, 1);
    // Start is called before the first frame update
    public GameObject cubeR, cubeL;
    public Camera cam;
    [SerializeField]
    private bool printDist;
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        cubeR.transform.position = new Vector3(X_Axis, cam.transform.position.y, distance.z);
        cubeL.transform.position = new Vector3(-X_Axis, cam.transform.position.y, distance.z);

        if (printDist)
        {
            float distance = Vector3.Distance(cubeR.transform.position, cubeL.transform.position);
            print("Maybe IPD is: " + distance);
        }
    }
}
