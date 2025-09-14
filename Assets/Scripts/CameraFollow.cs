using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Transform")]
    public Transform position;

    void FixedUpdate()
    {
        transform.position = position.position;
    }
}
