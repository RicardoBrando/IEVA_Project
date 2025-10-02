using System.Linq;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [Header("Checkpoints")]
    public GameObject _currentCheckpoint;
    public GameObject _startCheckpoint;

    private void Start()
    {
        GameObject[] checkpoints;
        GameObject[] cps = GameObject.FindGameObjectsWithTag("Respawn");
        checkpoints = new GameObject[cps.Length];
        int j = cps.Length - 1;
        for (int i = 0; i < cps.Length; i++)
        {
            checkpoints[j] = cps[i];
            j--;
        }

        _currentCheckpoint = checkpoints[0];
        _startCheckpoint = checkpoints[0];
    }

    private void Update()
    {
        if (Input.GetButtonDown("Respawn"))
            Respawn(true);
    }

    public void SetRespawnPoint(GameObject point)
    {
        _currentCheckpoint = point;
    }

    public void Respawn(bool start)
    {
        transform.gameObject.SetActive(false);
        if (start)
        {
            transform.position = _startCheckpoint.transform.position;
            transform.rotation = _startCheckpoint.transform.rotation;
            _currentCheckpoint = _startCheckpoint;
        }
        else
        {
            transform.position = _currentCheckpoint.transform.position;
            transform.rotation = _currentCheckpoint.transform.rotation;
        }
            
        transform.gameObject.SetActive(true);
    }
}
