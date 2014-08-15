using UnityEngine;
using System.Collections;

public class Detonator : ButtonEventHandler {
    public TNT Tnt;
    public override void OnButtonDown()
    {
        if (Tnt == null) return;
        Tnt.OnExplosion(0.01f, Tnt.transform.position);
    }
    public override void OnButtonUp()
    {
    }
}
