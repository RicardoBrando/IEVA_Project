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
            int score = Mathf.FloorToInt(1000f / IGTimer.GetComponent<InGameTimer>().levelTime);

            if (levelNumber == 1)
            {
                SaveDataScript.GlobalData.level1TimeScores.Add(score);
                SaveDataScript.GlobalData.level1TimeScores.Sort();
            }
            else if (levelNumber == 2)
            {
                SaveDataScript.GlobalData.level2TimeScores.Add(score);
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