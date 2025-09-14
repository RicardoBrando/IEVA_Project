using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [Header("Transform")]
    public Transform cameraPosition;

    void FixedUpdate()
    {
        transform.position = cameraPosition.position;
    }
}
