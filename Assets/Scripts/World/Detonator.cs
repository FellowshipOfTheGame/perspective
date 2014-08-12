using UnityEngine;
using System.Collections;

public class Detonator : ButtonEventHandler {
    public GameObject tnt;
    public override void OnButtonDown()
    {
        if (tnt == null) return;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            if (!player.GetComponent<PlayerDeath>().IsAlive) continue;
            if (tnt.GetComponent<ExplosionHandler>() != null)
                tnt.GetComponent<ExplosionHandler>().OnExplosion(player);
        }
    }
    public override void OnButtonUp()
    {
    }
}
