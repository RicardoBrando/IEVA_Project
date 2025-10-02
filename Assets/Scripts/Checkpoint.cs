using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [Header("Properties")]
    public bool isSpawnPoint;

    [Header("Scene objects")]
    public GameObject playerPrefab;

    private void Start()
    {
        if (isSpawnPoint)
            playerPrefab = Instantiate(playerPrefab, transform.position, transform.rotation);
    }
}
