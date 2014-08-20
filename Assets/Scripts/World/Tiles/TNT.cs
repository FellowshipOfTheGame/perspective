using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
public class TNT : ExplosionEventHandler
{
    public float ExplosionRadius = 1.0f;
    public AudioClipArray TntAudioClip;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            OnExplosion(ExplosionRadius, transform.position);
    }

    public void Update()
    {
        if (gameObject.activeSelf && !Enabled)
        {
            Enabled = true;
        }
    }

    public override void OnExplosion(float radius, Vector3 position)
    {
        if (Enabled && Vector3.Distance(position, transform.position) - collider.bounds.extents.x < radius)
        {
            Enabled = false;
            Master.OnTntExplode(ExplosionRadius, transform.position);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                if (Vector3.Distance(player.transform.position, transform.position) - ((CapsuleCollider)player.collider).height < radius)
                {
                    PlayerDeath death = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath>();
                    if (death != null)
                        death.OnDeath();
                }
            }
            TntAudioClip.PlayNextAtPoint(transform.position);
            //DestroyObject(gameObject);
            gameObject.SetActive(false);
        }
    }

    protected override void OnPerspectiveActivated()
    {
        Enabled = true;
    }

    protected override void OnPerspectiveDeactivated()
    {
        Enabled = false;
    }
}
