using System.Linq;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [Header("Checkpoints")]
    public GameObject[] checkpoints;
    private GameObject _currentCheckpoint;

    private void Start()
    {
        GameObject[] cps = GameObject.FindGameObjectsWithTag("Respawn");
        checkpoints = new GameObject[cps.Length];
        int j = cps.Length - 1;
        for (int i = 0; i < cps.Length; i++)
        {
            checkpoints[j] = cps[i];
            j--;
        }

        _currentCheckpoint = checkpoints[0];
    }

    public void Respawn()
    {

    }
}
