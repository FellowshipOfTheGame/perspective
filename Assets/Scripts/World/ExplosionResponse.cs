using System.Collections;
using UnityEngine;

public abstract class ExplosionResponse : MonoBehaviour
{
    public abstract IEnumerator Explode();
    public bool HasExploded;
}
