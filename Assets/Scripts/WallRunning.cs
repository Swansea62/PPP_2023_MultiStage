using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRunning : MonoBehaviour
{
    //  Youtube link for Wallrunning script:
    //  https://www.youtube.com/watch?v=gNt9wBOrQO4

    [Header("Wallrunning")]
    public LayerMask isWall;
    public LayerMask isGround;
    public float wallRunForce;
    public float maxRunTime;
    private float wallRunTimer;

    [Header("Input")]
    public float horizontalInput;
    public float verticalInput;

    [Header("Detection")]
    public float wallCheckDistance;
    public float minJumpHeight;
    private RaycastHit leftWallHit;
    private RaycastHit rightWallHit;
    private bool wallLeft;
    private bool wallRight;

    [Header("References")]
    public Transform orientation;
    private Movement mv;
    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mv = GetComponent<Movement>();
    }

    private void Update()
    {
        CheckForWall();
    }

    private void CheckForWall()
    {
        wallRight = Physics.Raycast(transform.position, orientation.right, out rightWallHit, wallCheckDistance, isWall);
        wallLeft = Physics.Raycast(transform.position, -orientation.right, out leftWallHit, wallCheckDistance, isWall);
    }

    private bool AboveGround()
    {
        return !Physics.Raycast(transform.position, Vector3.down, minJumpHeight, isGround);
    }

    private void StateMachine()
    {
        //Let's get some inputs!
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Wallrunning State
        if((wallLeft || wallRight) && verticalInput > 0 && AboveGround())
        {
            //Start wallrunning

        }
    }


    private void StartWallRun()
    {
        
    }

    private void WallRunningMovement()
    {

    }

    private void StopWallRun()
    {

    }
}
