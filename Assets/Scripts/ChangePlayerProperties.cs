using UnityEngine;

public class ChangePlayerProperties : MonoBehaviour
{
    public float wallRunTime;
    public float gravityCounterforce;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("PlayerObject")) return;
        other.transform.parent.GetComponent<WallRunning>().ChangeWallRunTime(wallRunTime);
        other.transform.parent.GetComponent<WallRunning>().ChangeGravityCounterforce(gravityCounterforce);
    }
}
