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
        Destroy(this.gameObject);

        Vector3 directionToTarget = target.position - transform.position;
        agent.SetDestination(directionToTarget);
    }
}
