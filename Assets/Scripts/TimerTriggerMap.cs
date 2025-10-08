using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public GameObject IGTimer;
    public bool isEndTrigger;
    public int levelNumber; 

    private void Start()
    {
        transform.gameObject.SetActive(true);
        transform.gameObject.GetComponent<Collider>().enabled = true;
    }

    void Update()
    {
        if (isEndTrigger && transform.gameObject.GetComponent<Collider>().enabled == false)
        {

            int score2 = Mathf.FloorToInt(1000f / IGTimer.GetComponent<InGameTimer>().levelTime);

            if (levelNumber == 1)
            {
                float levelTime = IGTimer.GetComponent<InGameTimer>().levelTime; // en secondes
                int maxTimerScore = 1000;

                float bestTime = 60f;   
                float worstTime = 150f; 

                float t = Mathf.InverseLerp(worstTime, bestTime, levelTime);
                int timerScore = Mathf.RoundToInt(t * maxTimerScore);
                Debug.Log(timerScore);
                int TargetScore = SaveDataScript.instance.targetPoints * 100; 

                SaveDataScript.GlobalData.level1TimeScores.Add(timerScore + TargetScore);
                SaveDataScript.GlobalData.level1TimeScores.Sort();
            }
            else if (levelNumber == 2)
            {
                SaveDataScript.GlobalData.level2TimeScores.Add(1);
                SaveDataScript.GlobalData.level2TimeScores.Sort();
            }
            SaveDataScript.instance.SaveToJson();

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