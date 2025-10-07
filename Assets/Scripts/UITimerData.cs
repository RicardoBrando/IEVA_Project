using TMPro;
using UnityEngine;

public class UITimerData : MonoBehaviour
{
    [Header("Gun")]

    public TMP_Text TimerValue;
    public GameObject Timer;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimerValue.SetText("" +(Mathf.Round(Timer.GetComponent<InGameTimer>().levelTime * 100)) / 100.0);
    }
}
