using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform indicator;
    public Transform mainCamera;

    private float indicatorYPos = 0.025f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        indicator.position = new Vector3(mainCamera.position.x, indicatorYPos, mainCamera.position.z);
    }
}
