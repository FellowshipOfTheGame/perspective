using UnityEngine;
using System.Collections;

public abstract class ExplosionEventHandler : PerspectiveResponse
{
    public bool Enabled = true;
    public ExplosionMaster Master;
    public abstract void OnExplosion(float radius, Vector3 position);
}
