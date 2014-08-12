using UnityEngine;
using System.Collections;

public class ExplosionHandler : LayerEventHandler
{
    public bool Enabled = true;
    public GameObject[] nearObjects;
    public void OnExplosion(GameObject player)
    {
        if (!Enabled) return;
        Enabled = false;
        foreach (GameObject obj in nearObjects)
        {
            if (obj == null) continue;
            if(obj.GetComponent<ExplosionHandler>() != null)
                obj.GetComponent<ExplosionHandler>().OnExplosion(player);
        }
        if(this.GetComponent<TNT>() != null)
        {
            if (Vector3.Distance(this.transform.position, player.transform.position) <= this.GetComponent<TNT>().ExplosionRadius)
                player.GetComponent<PlayerDeath>().OnDeath();
        }
        //TODO: Don't explode, or recreate on respawn
        if(GetComponentInParent<Layer>() != null)
            GetComponentInParent<Layer>().RemoveEvents(this.gameObject);
        DestroyObject(gameObject);
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
