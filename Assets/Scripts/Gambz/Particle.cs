using System.Collections;
using UnityEngine;

[RequireComponent(typeof (Animation))]
public class Particle : MonoBehaviour
{
    public float duration = 1f;
    public void Awake()
    {
        StartCoroutine(DestroyOn(duration));
    }

    private IEnumerator DestroyOn(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}