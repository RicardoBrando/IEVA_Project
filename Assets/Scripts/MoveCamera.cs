using System.Collections;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [Header("Transform")]
    public Transform cameraPosition = null;

    void FixedUpdate()
    {
        if (cameraPosition == null) return;
        transform.position = cameraPosition.position;
    }

    public void SetCameraPosition(Transform cameraPosition)
    {
        this.cameraPosition = cameraPosition;
    }
}
