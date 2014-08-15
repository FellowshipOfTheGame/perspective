using UnityEngine;
using System;

public class ExplosionMaster : MonoBehaviour
{
    public delegate void ExplosionDelegate(float radius, Vector3 position);
    private event ExplosionDelegate OnExplosion;

    public new void Start()
    {
        foreach (ExplosionEventHandler explosionHandler in GetComponentsInChildren<ExplosionEventHandler>())
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                OnExplosion -= explosionHandler.OnExplosion;
            }
#endif
            OnExplosion += explosionHandler.OnExplosion;
        }
    }
    public new void RemoveEvents(GameObject obj)
    {
        foreach (ExplosionEventHandler explosionHandler in obj.GetComponents<ExplosionEventHandler>())
            OnExplosion -= explosionHandler.OnExplosion;
    }

    public void OnTntExplode(float radius, Vector3 position)
    {
        if (OnExplosion != null)
            OnExplosion(radius, position);
    }
}
