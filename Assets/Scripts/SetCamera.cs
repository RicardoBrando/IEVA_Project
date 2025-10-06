using UnityEngine;

public class SetCamera : MonoBehaviour
{
    public MoveCamera cameraHolder;
    public CameraMovement cameraMovement;
    public Transform orientation;
    public Transform cameraPosition;
    public PlayerMovement pm;

    private void Start()
    {
        cameraHolder = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MoveCamera>();
        cameraMovement = cameraHolder.transform.GetChild(0).GetComponent<CameraMovement>();
        cameraHolder.SetCameraPosition(cameraPosition);
        cameraMovement.SetOrientation(orientation);
        cameraMovement.SetPlayerMovement(pm);
        transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
    }
}
