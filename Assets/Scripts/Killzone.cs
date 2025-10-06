using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Killzone : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Player"))
            return;
        collider.transform.parent.GetComponent<PlayerRespawn>().Respawn(false);
    }
}
