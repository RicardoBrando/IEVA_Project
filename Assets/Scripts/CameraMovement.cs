using System.Collections;
using System.Net;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Attributes")]
    public float sensX;
    public float sensY;
    public float xRotation;
    public float yRotation;
    public bool isLocked;


    [Header("Transforms")]
    public Transform orientation = null;

    public PlayerMovement pm;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isLocked = true;
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        xRotation -= mouseY;
        yRotation += mouseX;

        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        
        if(isLocked)
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    public void SetOrientation(Transform orientation)
    {
        this.orientation = orientation;
    }

    public void SetPlayerMovement(PlayerMovement pm)
    {
        this.pm = pm;
    }

    public void UnlockCamera()
    {
        isLocked = false;
    }

    public void LockCamera()
    {
        isLocked = true;
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
