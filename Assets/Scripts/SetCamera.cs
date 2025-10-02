using UnityEngine;

public class SetCamera : MonoBehaviour
{
    private MoveCamera cameraHolder;
    private CameraMovement cameraMovement;
    public Transform orientation;
    public Transform cameraPosition;

    private void Start()
    {
        cameraHolder = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MoveCamera>();
        cameraMovement = cameraHolder.transform.GetChild(0).GetComponent<CameraMovement>();
        cameraHolder.SetCameraPosition(cameraPosition);
        cameraMovement.SetOrientation(orientation);
    }
}
