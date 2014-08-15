using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
public class TNT : ExplosionEventHandler
{
    public float ExplosionRadius = 1.0f;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            OnExplosion(ExplosionRadius, transform.position);
    }

    public override void OnExplosion(float radius, Vector3 position)
    {
        if (Enabled && MathUtility.SqrDistance(position, transform.position) - collider.bounds.extents.x < radius * radius)
        {
            Enabled = false;
            Master.OnTntExplode(ExplosionRadius, transform.position);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                PlayerDeath death = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath>();
                if (death != null)
                    death.OnDeath();
            }
            Master.RemoveEvents(gameObject);
            Layer layer = GetComponentInParent<Layer>();
            if (layer != null)
                layer.RemoveEvents(gameObject);
            DestroyObject(gameObject);

        }
    }

    public override void OnLayerEnabled()
    {
        Enabled = true;
    }
    public override void OnLayerDisabled()
    {
        Enabled = false;
    }
}
