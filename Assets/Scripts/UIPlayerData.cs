using System.Collections;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;

public class UIPlayerData : MonoBehaviour
{
    [Header("Player")]
    public Rigidbody playerRb = null;
    public TMP_Text Ui_speed;

    private void Start()
    {
        StopAllCoroutines();
        StartCoroutine(FindPlayerRigidbody());
    }

    private void Update()
    {
        if(playerRb != null)
            Ui_speed.SetText("Speed : "+playerRb.linearVelocity.magnitude.ToString("F2"));
    }

    public void SetPlayerRb(Rigidbody playerRb)
    {
        this.playerRb = playerRb;
    }

    private IEnumerator FindPlayerRigidbody()
    {
        while(playerRb == null)
        {
            GameObject player = null;
            player = GameObject.FindGameObjectWithTag("Player");
            if(player != null)
                playerRb = player.GetComponent<Rigidbody>();

            yield return null;
        }
    }
}
