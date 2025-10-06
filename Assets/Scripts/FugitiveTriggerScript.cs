using UnityEngine;

public class FugitivetTriggerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject fugitive;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("PlayerObject"))
            return;
        fugitive.GetComponent<FugitiveScript>().PlayerIsTrigger = true;
    }
}
