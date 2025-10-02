using System.Collections;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    public Transform FirePoint;
    public int magSize;
    public int maxMagSize;
    public int currentMagSize;
    private int timeToReload = 2;
    private bool isReloading = false;
    public Animator GunReloadAnimator;

    
    private void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isReloading == false)
            {
                if (currentMagSize == 0 && magSize > 0)
                {
                    StartCoroutine(reloadGun());
                }

                if (currentMagSize > 0)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(FirePoint.position, transform.TransformDirection(Vector3.forward), out hit, 100))
                    {
                        hit.collider.SendMessage("HitByBullet", SendMessageOptions.DontRequireReceiver);
                    }
                    emptyChamber();
                }
            }

        }
        Debug.DrawRay(FirePoint.position, transform.TransformDirection(Vector3.forward) * 100, Color.red);
    }
    public void emptyChamber()
    {
        currentMagSize--;
    }

    public void refillGun(int bulletNumber)
    {
        int newMagSize = magSize + bulletNumber;
        magSize = newMagSize > maxMagSize ? maxMagSize : newMagSize;
    }
    public IEnumerator reloadGun()
    {
        isReloading = true;
        GunReloadAnimator.enabled = true;
        yield return new WaitForSeconds(timeToReload);
        if (magSize <= 5)
        {
            currentMagSize = magSize;
            magSize = 0;
        }
        else
        {
            currentMagSize = 5;
            magSize -= 5;
        }
        GunReloadAnimator.enabled = false;
        isReloading = false;
    }
}
