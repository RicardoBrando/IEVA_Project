using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CheckpointTrigger : MonoBehaviour
{
    public PlayerRespawn playerRespawn;
    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("CheckpointTrigger"))
            return;
        playerRespawn.SetRespawnPoint(collider.transform.parent.gameObject);
    }
}
