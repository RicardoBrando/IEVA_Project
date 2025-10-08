using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class FugitiveScript : MonoBehaviour
{

    public Transform target;
    public bool PlayerIsTrigger = false;
    public string FugitiveColor;
    private NavMeshAgent agent;
    public string levelNumber;
    void Start()
    {
        UnityEngine.ColorUtility.TryParseHtmlString(FugitiveColor, out var CurrentColor);
        GetComponent<MeshRenderer>().material.SetColor("_Color", CurrentColor);
        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;

    }
    void Update()
    {
        if (PlayerIsTrigger)
        {
            agent.SetDestination(target.position);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("PlayerObject"))
            return;
        if (levelNumber == "0")
        {
            SaveDataScript.GlobalData.fugitiveGotCaughtLevel1 = true;
        }
        else if (levelNumber == "1")
        {
            SaveDataScript.GlobalData.fugitiveGotCaughtLevel2 = true;
        }
        Destroy(this.transform.parent.gameObject);
    }
}
