using UnityEngine;

public class InGameTimer : MonoBehaviour
{


    public float levelTime = 00.00f;
    public bool isPlaying = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            levelTime += Time.deltaTime;
        }
    }

}
