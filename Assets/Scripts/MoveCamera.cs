using System.Collections;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [Header("Transform")]
    public Transform cameraPosition = null;
    private bool cameraFound;

    private void Start()
    {
        StartCoroutine(SearchForPlayerCameraPositionCoroutine());
    }

    void FixedUpdate()
    {
        if(cameraFound)
            transform.position = cameraPosition.position;
    }

    private IEnumerator SearchForPlayerCameraPositionCoroutine()
    {
        while(cameraPosition == null)
        {
            cameraPosition = GameObject.FindGameObjectWithTag("PlayerCameraPosition").transform;
            yield return null;
        }
        cameraFound = true;
    }
}
