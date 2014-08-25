using UnityEngine;
using System.Collections;

public class DestroyOnExplosion : ExplosionResponse
{
    public void Start()
    {
        if (collider == null)
        {
            gameObject.AddComponent<BoxCollider>();
        }
    }

    public override IEnumerator Explode()
    {
        HasExploded = true;
        Destroy(gameObject);
        yield break;
    }
}