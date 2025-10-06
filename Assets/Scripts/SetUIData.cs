using UnityEngine;

public class SetUIData : MonoBehaviour
{
    public Rigidbody rb;
    void Start()
    {
        GameObject.FindGameObjectWithTag("DebugUI").GetComponent<UIPlayerData>().SetPlayerRb(rb);
    }
}
