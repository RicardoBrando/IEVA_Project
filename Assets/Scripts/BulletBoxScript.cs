using UnityEngine;

public class BulletBoxScript : MonoBehaviour
{

    private int BulletNumber = 5;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("zzzz");
        if (other.gameObject.tag == "PlayerObject")
        {
            Debug.Log("oudqzzi");
        }
    }
}
