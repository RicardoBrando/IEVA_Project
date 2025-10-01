using UnityEngine;

public class GunScript : MonoBehaviour
{

    public Transform FirePoint;
    
    
    private void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(FirePoint.position, transform.TransformDirection(Vector3.forward), out hit, 100))
            {
                hit.collider.SendMessage("HitByBullet", SendMessageOptions.DontRequireReceiver);
            }
        }
        Debug.DrawRay(FirePoint.position, transform.TransformDirection(Vector3.forward) * 100, Color.red);
    }
}
