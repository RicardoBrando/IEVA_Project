using UnityEngine;

public class TargetColliderScript : MonoBehaviour
{



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    void HitByBullet()
    {
        Debug.Log("Cible Touchée");
        Destroy(gameObject);
    }
}
