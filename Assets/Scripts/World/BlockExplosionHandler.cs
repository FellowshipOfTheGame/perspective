﻿using UnityEngine;
using System.Collections;

public class BlockExplosionHandler : ExplosionEventHandler
{

    public override void OnExplosion(float radius, Vector3 position)
    {
        if (Enabled && MathUtility.SqrDistance(position, transform.position) - collider.bounds.extents.x < radius * radius)
        {
            Enabled = false;
            Layer layer = GetComponentInParent<Layer>();
            if(layer != null)
                layer.RemoveEvents(gameObject);
            Master.RemoveEvents(gameObject);
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
