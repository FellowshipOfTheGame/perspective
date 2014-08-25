using UnityEngine;

[RequireComponent(typeof(ExplosionResponse))]
public class ExplodeFromButton : ButtonResponse {
    public override void OnButtonDown(GameObject other)
    {

        StartCoroutine(GetComponent<ExplosionResponse>().Explode());
    }
}
