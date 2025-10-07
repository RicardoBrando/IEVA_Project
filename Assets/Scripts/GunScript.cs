using System.Collections;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    public Transform FirePoint;
    public int magSize;
    public int maxMagSize;
    public int currentMagSize;
    public int maxCurrentMagSize;

    private int timeToReload = 2;
    private bool isReloading = false;
    public Animator GunReloadAnimator;
    public ParticleSystem GunShotParticleSystem;

    private void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isReloading == false)
            {
                if (currentMagSize <= 0 && magSize > 0)
                {
                    StartCoroutine(reloadGun());
                }

                if (currentMagSize > 0)
                {
                    GunShotParticleSystem.Play();
                    RaycastHit hit;
                    Debug.DrawRay(FirePoint.position, transform.TransformDirection(Vector3.forward) * 10000, Color.red);
                    if (Physics.Raycast(FirePoint.position, transform.TransformDirection(Vector3.forward), out hit, 10000))
                    {
                        hit.collider.SendMessage("HitByBullet", SendMessageOptions.DontRequireReceiver);
                    }
                    emptyChamber();
                }
            }

        }
        if (Input.GetButton("Reload"))
        {
            if (isReloading == false && currentMagSize < maxCurrentMagSize && magSize > 0)
            {
                StartCoroutine(reloadGun());
            }
        }
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

        int bulletsNeededToFillCurrentMag = maxCurrentMagSize - currentMagSize;

        int bulletsToLoad = Mathf.Min(bulletsNeededToFillCurrentMag, magSize);

        currentMagSize += bulletsToLoad;
        magSize -= bulletsToLoad;

        GunReloadAnimator.enabled = false;
        isReloading = false;
    }
}
