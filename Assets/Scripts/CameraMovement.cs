using System.Collections;
using System.Net;
using UnityEngine;
using DG.Tweening;

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
    public Transform camHolder;

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

        camHolder.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        
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

    public void DoFov(float endValue)
    {
        GetComponent<Camera>().DOFieldOfView(endValue, 0.25f);
    }

    public void DoTilt(float zTilt)
    {
        transform.DOLocalRotate(new Vector3(0, 0, zTilt), 0.25f);
    }
}
