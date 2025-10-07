using UnityEngine;

public class TimerTriggerMap2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject IGTimer;
    public bool isEndTrigger;

    private void Start()
    {
        transform.gameObject.SetActive(true);
        transform.gameObject.GetComponent<Collider>().enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (isEndTrigger && transform.gameObject.GetComponent<Collider>().enabled == false)
        {
            Debug.Log("ouuu");
            SaveDataScript.GlobalData.level2TimeScores.Add(Mathf.FloorToInt(1000f /IGTimer.GetComponent<InGameTimer>().levelTime));
            SaveDataScript.GlobalData.level2TimeScores.Sort();
            transform.gameObject.SetActive(false);
            
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("PlayerObject"))
            return;
        IGTimer.GetComponent<InGameTimer>().isPlaying = !IGTimer.GetComponent<InGameTimer>().isPlaying;
        transform.gameObject.GetComponent<Collider>().enabled = false;
    }
}
