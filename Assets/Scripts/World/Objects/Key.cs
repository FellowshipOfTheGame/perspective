using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Key : MonoBehaviour
{
    public KeyEventHandler KeyTrigger;

    void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger && other.gameObject.CompareTag("Player"))
        {
            KeyTrigger.OnKeyAcquired();
            DestroyObject(gameObject);
        }
    }

}
