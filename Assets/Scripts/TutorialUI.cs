using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    public GameObject[] panels;
    private int current;
    private bool displayTutorialUI;

    private void Start()
    {
        current = 0;
    }

    private void Update()
    {
        if (current == 0) StartTutorial();
        else Close();
    }

    public void Next()
    {
        if (!displayTutorialUI) return;
        current++;
        if (current >= panels.Length) return;
        panels[current].gameObject.SetActive(true);
    }

    private void StartTutorial()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            displayTutorialUI = true;
            panels[current].SetActive(false);
            Next();
        }
            
        else if (Input.GetKeyDown(KeyCode.N))
        {
            displayTutorialUI = false;
            panels[current].SetActive(false);
            Next();
        }
    }

    private void Close()
    {
        if (Input.GetKeyDown(KeyCode.K) && panels[current].activeSelf)
        {
            panels[current].SetActive(false);
        }
    }
}
