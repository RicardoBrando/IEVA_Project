using TMPro;
using UnityEngine;

public class UIPlayerData : MonoBehaviour
{
    [Header("Player")]
    public Rigidbody playerRb;
    public GameObject Gun;


    public TMP_Text Ui_speed;
    public TMP_Text MagSize;


    private void Update()
    {
        Ui_speed.SetText("Speed : "+playerRb.linearVelocity.magnitude.ToString("F2"));
        MagSize.SetText("MagSize : " + Gun.GetComponent<GunScript>().currentMagSize + "/" + Gun.GetComponent<GunScript>().magSize);
    }
}
