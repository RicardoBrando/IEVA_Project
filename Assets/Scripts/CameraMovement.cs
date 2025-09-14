using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Attributes")]
    public float sensX;
    public float sensY;
    public float xRotation;
    public float yRotation;

    [Header("Transforms")]
    public Transform orientation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        xRotation -= mouseY;
        yRotation += mouseX;

        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
