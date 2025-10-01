using TMPro;
using UnityEditor.SearchService;
using UnityEngine;

public class UIPlayerData : MonoBehaviour
{
    [Header("Player")]
    public Rigidbody playerRb;

    public TMP_Text Ui_speed;

    private void Update()
    {
        Ui_speed.SetText("Speed : "+playerRb.linearVelocity.magnitude.ToString("F2"));
    }
}
