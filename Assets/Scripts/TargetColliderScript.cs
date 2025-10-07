using Unity.VisualScripting;
using UnityEngine;

public class TargetColliderScript : MonoBehaviour
{

    bool playerDetected = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("PlayerObject");
        if (player != null && !playerDetected)
        {
            Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
            playerDetected = true;
        }
    }
    void HitByBullet()
    {
        Debug.Log("Cible Touchée");

        Destroy(gameObject);
    }
    
}
