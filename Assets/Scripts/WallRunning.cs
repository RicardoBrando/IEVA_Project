using UnityEditor.SearchService;
using UnityEngine;

public class WallRunning : MonoBehaviour
{
    [Header("WallRunning")]
    public LayerMask whatIsWall;
    public LayerMask whatIsGround;
    public float wallRunForce;
    public float maxWallRunTime;
    private float _wallRunTimer;

    [Header("WallJump")]
    public float wallJumpForce;
    public float wallJumpSideForce;

    [Header("Input")]
    private float _horizontalInput;
    private float _verticalInput;

    [Header("Detection")]
    public float wallCheckDistance;
    public float minJumpHeight;
    private RaycastHit _leftWallHit;
    private RaycastHit _rightWallHit;
    private bool _leftWall;
    private bool _rightWall;

    [Header("Exiting")]
    private bool exitingWall;
    public float exitWallTime;
    private float exitWallTimer;

    [Header("Gravity")]
    public bool useGravity = true;
    public float gravityCounterForce;

    [Header("References")]
    public CameraMovement cm;
    public Transform orientation;
    private PlayerMovement pm;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();
        cm = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
    }

    private void FixedUpdate()
    {
        if (pm.isWallrunning)
            WallrunMovement();
    }

    private void Update()
    {
        CheckWallHit();
        StateMachine();
    }

    private void CheckWallHit()
    {
        _rightWall = Physics.Raycast(transform.position, orientation.right, out _rightWallHit, wallCheckDistance, whatIsWall);
        _leftWall = Physics.Raycast(transform.position, -orientation.right, out _leftWallHit, wallCheckDistance, whatIsWall);
    }

    private bool AboveGround()
    {
        return !Physics.Raycast(transform.position, Vector3.down, minJumpHeight, whatIsGround);
    }

    private void StateMachine()
    {
        // Get inputs
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        // State 1 - Wallrunning
        if((_leftWall || _rightWall) && _verticalInput > 0 && AboveGround() && !exitingWall)
        {
            // Start Wallrunning
            if(!pm.isWallrunning)
                StartWallrun();

            if (_wallRunTimer > 0)
                _wallRunTimer -= Time.deltaTime;

            if (_wallRunTimer <= 0)
            {
                exitingWall = true;
                exitWallTimer = exitWallTime;
            }
                

            if (Input.GetButton("Jump"))
                WallJump();
        }

        // State 2 - Exiting wall
        else if(exitingWall)
        {
            if (pm.isWallrunning)
                StopWallrun();

            if (exitWallTimer > 0)
                exitWallTimer -= Time.deltaTime;

            if(exitWallTimer <= 0)
                exitingWall = false;
        }

        else
        {
            if (pm.isWallrunning)
                StopWallrun();
        }
    }

    private void StartWallrun()
    {
        pm.isWallrunning = true;
        _wallRunTimer = maxWallRunTime;
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        cm.UnlockCamera();

        // camera effect
        cm.DoFov(90f);
        if(_leftWall) cm.DoTilt(-5f);
        if(_rightWall) cm.DoTilt(5f);
    }

    private void WallrunMovement()
    {
        rb.useGravity = useGravity;

        Vector3 wallNormal = _rightWall ? _rightWallHit.normal : _leftWallHit.normal;
        Vector3 wallForward = Vector3.Cross(wallNormal, Vector3.up);

        if((orientation.forward - wallForward).magnitude > (orientation.forward - -wallForward).magnitude)
            wallForward = -wallForward;

        orientation.forward = wallForward;

        // Forward force
        rb.AddForce(wallForward * wallRunForce, ForceMode.Force);

        // Force to wall
        if(!(_leftWall && _horizontalInput > 0) && !(_rightWall && _horizontalInput > 0))
            rb.AddForce(-wallNormal * 100, ForceMode.Force);

        if(useGravity)
            rb.AddForce(transform.up * gravityCounterForce, ForceMode.Force);
    }

    private void StopWallrun()
    {
        rb.useGravity = true;
        pm.isWallrunning = false;
        cm.LockCamera();
        cm.DoFov(80f);
        cm.DoTilt(0f);
    }

    private void WallJump()
    {
        exitingWall = true;
        exitWallTimer = exitWallTime;

        Vector3 wallNormal = _rightWall ? _rightWallHit.normal : _leftWallHit.normal;
        Vector3 forceToApply = transform.up * wallJumpForce + wallNormal * wallJumpSideForce;

        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.AddForce(forceToApply, ForceMode.Impulse);
    }
}
