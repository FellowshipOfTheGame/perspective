using UnityEngine;
using System.Collections;

public class BlockExplosionHandler : ExplosionEventHandler
{

    public override void OnExplosion(float radius, Vector3 position)
    {
        if (Enabled && MathUtility.SqrDistance(position, transform.position) - collider.bounds.extents.x < radius * radius)
        {
            Enabled = false;
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
