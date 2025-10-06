using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CheckpointTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Player"))
            return;
        collider.transform.parent.GetComponent<PlayerRespawn>().SetRespawnPoint(transform.parent.gameObject);
    }
}
