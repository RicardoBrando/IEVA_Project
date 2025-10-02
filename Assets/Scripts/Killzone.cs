using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Killzone : MonoBehaviour
{
    [SerializeField] public UnityEvent onTriggerEnter;

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Killzone"))
            return;
        onTriggerEnter?.Invoke();
    }
}
