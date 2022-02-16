using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRoller : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject ball;
    private Rigidbody rb;
    private float ballRollDistance;

    [Header("Press this to reset the ball")]
    public bool resetBall = false;

    [Header("Select Force (9.5 will make it go close to the tables)")]
    [Range(0f,9.5f)]public float force = 0f;    

    [Header("Press this to roll the ball")]
    public bool pushBall = false;

    [Header("Press this to print distance to the ball")]
    public bool distance = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(resetBall) {
            resetBall = false;
            ball.transform.position = startPoint.transform.position;
        }

        if(distance){
            distance = false;
            if(ball){
                ballRollDistance = Vector3.Distance(startPoint.transform.position, ball.transform.position);
                print("The ball rolled a distance of " + ballRollDistance + " meters");
            }
        }
    }

    void FixedUpdate()
    {
        if(pushBall) {
            pushBall = false;
            rb.AddForce(0, 0, force, ForceMode.Impulse);
        }
    }
}
