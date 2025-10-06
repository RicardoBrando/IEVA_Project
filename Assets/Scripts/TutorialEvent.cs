using UnityEngine;

public class TutorialEvent : MonoBehaviour
{
    public GameObject[] gameObjects;

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("PlayerObject"))
            return;
        ActiveObjects();
    }

    public void ActiveObjects()
    {
        foreach (GameObject go in gameObjects)
        {
            go.SetActive(!go.activeSelf);
        }
    }
}
