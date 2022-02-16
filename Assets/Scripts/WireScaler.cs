using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireScaler : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    private Vector3 initialScale;
    private float distBetweenPoints;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
        print("Scaling object in start method");
        RescaleObject();
    }

    // Update is called once per frame
    void Update()
    {
        // Only do rescaling if either of the two points to scale between has changed
        if(startPoint.transform.hasChanged || endPoint.transform.hasChanged)
        {
            print("Rescaling object");
            RescaleObject();
        }
    }

    private void RescaleObject()
    {
        // Calculate the scale of the object
        distBetweenPoints = Vector3.Distance(startPoint.position, endPoint.position);
        transform.localScale = new Vector3(initialScale.x, distBetweenPoints/2f, initialScale.z);   // Division by 2 for a cylinder object

        // Calculate the position to place this object at
        Vector3 middlePoint = (startPoint.position + endPoint.position) / 2;    // find middle between the two points (where to put this object)
        transform.position = middlePoint;

        // Calculate how to rotate / where to face this object
        Vector3 rotationDirection = (endPoint.position - startPoint.position);
        transform.up = rotationDirection;
    }
}
