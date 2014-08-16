using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour
{
    public int Id;
    public KeyEventHandler KeyTrigger;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            KeyTrigger.OnKeyAcquired(Id);
            DestroyObject(gameObject);
        }
    }

}
