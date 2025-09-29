using UnityEngine;

public class Sliding : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform playerObj;
    private Rigidbody rb;
    private PlayerMovement pm;

    [Header("Sliding")]
    public float slideForce;
    private float horizontalInput, verticalInput;

    public float slideYScale;
    private float startYScale;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();
        startYScale = playerObj.localScale.y;
    }

    private void FixedUpdate()
    {
        if (pm.isSliding)
            SlidingMovement();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetButtonDown("Slide") && (horizontalInput != 0 || verticalInput != 0))
            StartSlide();

        if (Input.GetButtonUp("Slide") && pm.isSliding)
            StopSlide();
    }

    private void StartSlide()
    {
        //Debug.Log(rb.linearVelocity.y);
        if(pm.OnSlope() && rb.linearVelocity.y < -0.1f)
        {
            pm.isSliding = true;

            playerObj.localScale = new Vector3(playerObj.localScale.x, slideYScale, playerObj.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }
    }

    private void SlidingMovement()
    {
        Vector3 inputDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        //sliding on slope
        rb.AddForce(pm.GetSlopeMovementDirection(inputDirection) * slideForce, ForceMode.Force);
    }

    private void StopSlide()
    {
        pm.isSliding = false;
        playerObj.localScale = new Vector3(playerObj.localScale.x, startYScale, playerObj.localScale.z);
    }
}
