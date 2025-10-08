using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class FugitiveScript : MonoBehaviour
{

    public Transform target;
    public bool PlayerIsTrigger = false;
    private NavMeshAgent agent;
    void Start()
    {
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
        SaveDataScript.GlobalData.fugitiveGotCaughtLevel1 = true;
        Destroy(this.transform.parent.gameObject);

    }
}
