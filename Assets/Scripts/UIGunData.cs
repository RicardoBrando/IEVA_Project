using TMPro;
using UnityEngine;

public class UIGunData : MonoBehaviour
{
    [Header("Gun")]

    public TMP_Text MagSize;
    public GameObject Gun;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MagSize.SetText("MagSize : " + Gun.GetComponent<GunScript>().currentMagSize + "/" + Gun.GetComponent<GunScript>().magSize);
    }
}
