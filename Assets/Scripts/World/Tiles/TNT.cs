using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
public class TNT : MonoBehaviour
{
    public float ExplosionRadius = 1.0f;

    public void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contat in collision.contacts)
        {
            if (contat.otherCollider.gameObject.CompareTag("Player"))
            {
                ExplosionHandler handler = this.GetComponent<ExplosionHandler>();
                if (handler.Enabled)
                {
                    GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                    foreach (GameObject player in players)
                    {
                        if (!player.GetComponent<PlayerDeath>().IsAlive) continue;
                        handler.OnExplosion(player);
                        break;
                    }
                }
            }
        }
    }
}
