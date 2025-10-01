using UnityEditor;
using UnityEngine;

public class BulletBoxScript : MonoBehaviour
{
    public Animator BulletBoxAnimator;
    private int bulletNumber = 1;
    private float timeToDestroy = 4.0f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name);
        if (bulletNumber > 0)
        {
            if (other.CompareTag("PlayerObject"))
            {
                GameObject gun = GameObject.FindGameObjectWithTag("Gun");
                if (gun.GetComponent<GunScript>().magSize < gun.GetComponent<GunScript>().maxMagSize)
                {
                    BulletBoxAnimator.enabled = true;
                    gun.GetComponent<GunScript>().refillGun(bulletNumber);
                    bulletNumber = 0;
                    Invoke("DestroyBulletBox", timeToDestroy);
                }
            }
        }
    }


    private void DestroyBulletBox()
    {
        Destroy(BulletBoxAnimator.gameObject.transform.parent.gameObject);
    }

}