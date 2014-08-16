using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour
{
    public KeyEventHandler KeyTrigger;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            KeyTrigger.OnKeyAcquired();
            DestroyObject(gameObject);
        }
    }

}
