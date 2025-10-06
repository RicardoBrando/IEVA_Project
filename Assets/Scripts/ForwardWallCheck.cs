using Unity.VisualScripting;
using UnityEngine;

public class ForwardWallCheck : MonoBehaviour
{
    public PlayerMovement pm;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
            pm.forwardWall = true;
    }
}
