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

    [Header("References")]
    public Transform orientation;
    private PlayerMovement pm;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();
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
        if((_leftWall || _rightWall) && _verticalInput > 0 && AboveGround())
        {
            // Start Wallrunning
            if(!pm.isWallrunning)
                StartWallrun();

            if(Input.GetButton("Jump"))
                WallJump();
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
    }

    private void WallrunMovement()
    {
        rb.useGravity = false;
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        Vector3 wallNormal = _rightWall ? _rightWallHit.normal : _leftWallHit.normal;
        Vector3 wallForward = Vector3.Cross(wallNormal, Vector3.up);

        if((orientation.forward - wallForward).magnitude > (orientation.forward - -wallForward).magnitude)
            wallForward = -wallForward;

        // Forward force
        rb.AddForce(wallForward * wallRunForce, ForceMode.Force);

        // Force to wall
        if(!(_leftWall && _horizontalInput > 0) && !(_rightWall && _horizontalInput > 0))
            rb.AddForce(-wallNormal * 100, ForceMode.Force);
    }

    private void StopWallrun()
    {
        rb.useGravity = true;
        pm.isWallrunning = false;
    }

    private void WallJump()
    {
        Vector3 wallNormal = _rightWall ? _rightWallHit.normal : _leftWallHit.normal;
        Vector3 forceToApply = transform.up * wallJumpForce + wallNormal * wallJumpSideForce;

        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.AddForce(forceToApply, ForceMode.Impulse);
    }
}
