using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CheckpointTrigger : MonoBehaviour
{
    public TutorialUI tutorialUI;
    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("PlayerObject"))
            return;
        collider.transform.parent.GetComponent<PlayerRespawn>().SetRespawnPoint(transform.parent.gameObject);

        if (tutorialUI != null)
            tutorialUI.Next();
    }
}
