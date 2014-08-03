using UnityEngine;

public abstract class Death : MonoBehaviour {

    public abstract void OnDeath();

    [HideInInspector]
    public bool IsAlive = true;
}
