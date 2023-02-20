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
    public float wallJumpUpForce;
    public float wallJumpSideForce;
    public float maxWallRunTime;
    private float wallRunTimer;

    [Header("Input")]
    public KeyCode jumpKey = KeyCode.Space;
    public float horizontalInput;
    public float verticalInput;

    [Header("Detection")]
    public float wallCheckDistance;
    public float minJumpHeight;
    private RaycastHit leftWallHit;
    private RaycastHit rightWallHit;
    private bool wallLeft;
    private bool wallRight;

    [Header("Exiting")]
    private bool exitingWall;
    public float exitWallTime;
    private float exitWallTimer;

    [Header("Gravity")]
    public bool useGravity;
    public float gravityCounterForce;

    [Header("References")]
    public Transform orientation;
    public MouseLook cam;
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
        StateMachine();
    }

    private void FixedUpdate()
    {
        if(mv.wallrunning)
        {
            WallRunningMovement();
        }
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
            // Start wallrunning
            if (!mv.wallrunning)
            {
                StartWallRun();
            }

            // Wallrun timer
            if (wallRunTimer > 0)
            {
                wallRunTimer -= Time.deltaTime;
            }

            if (wallRunTimer <= 0 && mv.wallrunning)
            {
                exitingWall = true;
                exitWallTimer = exitWallTime;
            }

            if (Input.GetKeyDown(jumpKey))
            {
                WallJump();
            }
        }

        // Exiting wall
        else if (exitingWall)
        {
            if (mv.wallrunning)
            {
                StopWallRun();
            }

            if (exitWallTimer > 0)
            {
                exitWallTimer -= Time.deltaTime;
            }

            if (exitWallTimer <= 0)
            {
                exitingWall = false;
            }

        }

        else
        {
            if (mv.wallrunning)
            {
                StopWallRun();
            }
        }
    }


    private void StartWallRun()
    {
        mv.wallrunning = true;

        wallRunTimer = maxWallRunTime;

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // Apply cam effects
        cam.DoFov(90f);
        if (wallLeft)
        {
            cam.DoTilt(-5f);
        }
        if (wallRight)
        {
            cam.DoTilt(5f);
        }
    }

    private void WallRunningMovement()
    {
        rb.useGravity = useGravity;

        Vector3 wallNormal = wallRight ? rightWallHit.normal : leftWallHit.normal;

        Vector3 wallForward = Vector3.Cross(wallNormal, transform.up);

        if((orientation.forward - wallForward).magnitude > (orientation.forward - -wallForward).magnitude)
        {
            wallForward = -wallForward;
        }

        // Forward force
        rb.AddForce(wallForward * wallRunForce, ForceMode.Force);

        // Weakening gravity
        if (useGravity)
        {
            rb.AddForce(transform.up * gravityCounterForce, ForceMode.Force);
        }
    }

    private void StopWallRun()
    {
        mv.wallrunning = false;

        // Reset cam effects
        cam.DoFov(80f);
        cam.DoTilt(0f);
    }

    private void WallJump()
    {
        // Enter exiting wall state
        exitingWall = true;
        exitWallTimer = exitWallTime;

        Vector3 wallNormal = wallRight ? rightWallHit.normal : leftWallHit.normal;

        Vector3 forceToApply = transform.up * wallJumpUpForce + wallNormal * wallJumpSideForce;

        // Reset Y velocity and add force
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(forceToApply, ForceMode.Impulse);

    }
}
