using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    public float wallrunSpeed;
    public float slideSpeed;

    public float groundDrag;

    [Header("Jump")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public bool canJump;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool isGrounded;

    [Header("Slope Handling")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public PlayerState state;
    public enum PlayerState
    {
        walking,
        sprinting,
        wallrunning,
        sliding,
        airborne
    }

    public bool isWallrunning;
    public bool isSliding;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        canJump = true;
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        
        ReadInput();
        SpeedControl();
        StateHandler();

        if (isGrounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void ReadInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetButton("Jump") && canJump && isGrounded)
        {
            canJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void StateHandler()
    {
        // Mode - Sliding
        if(isSliding)
        {
            state = PlayerState.sliding;
            moveSpeed = slideSpeed;
        }

        // Mode - Wallrunning
        else if(isWallrunning)
        {
            state = PlayerState.wallrunning;
            moveSpeed = wallrunSpeed;
        }

        // Mode - Sprinting
        else if(isGrounded && Input.GetButton("Sprint"))
        {
            state = PlayerState.sprinting;
            moveSpeed = sprintSpeed;
        }

        // Mode - Walking
        else if(isGrounded)
        {
            state = PlayerState.walking;
            moveSpeed = walkSpeed;
        }

        // Mode - airborne
        else
        {
            state = PlayerState.airborne;
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if(OnSlope() && !exitingSlope)
        {
            rb.AddForce(GetSlopeMovementDirection(moveDirection) * moveSpeed * 10f, ForceMode.Force);
        }

        else if(isGrounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        else if(!isGrounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

        if(!isWallrunning) rb.useGravity = !OnSlope();
    }

    private void SpeedControl()
    {
        // limit movespeed on lope
        if (OnSlope() && !exitingSlope)
        {
            if(rb.linearVelocity.magnitude > moveSpeed)
                rb.linearVelocity = rb.linearVelocity.normalized * moveSpeed;
        }

        else
        {
            Vector3 flatSpeed = new Vector3(rb.linearVelocity.x, 0.0f, rb.linearVelocity.z);

            if (flatSpeed.magnitude > moveSpeed)
            {
                Vector3 limitedVelocity = flatSpeed.normalized * moveSpeed;
                rb.linearVelocity = new Vector3(limitedVelocity.x, rb.linearVelocity.y, limitedVelocity.z);
            }
        }
    }

    private void Jump()
    {
        exitingSlope = true;

        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        canJump = true;

        exitingSlope = false;
    }

    public bool OnSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle;
        }

        return false;
    }

    public Vector3 GetSlopeMovementDirection(Vector3 direction)
    {
        return Vector3.ProjectOnPlane(direction, slopeHit.normal).normalized;
    }
}
