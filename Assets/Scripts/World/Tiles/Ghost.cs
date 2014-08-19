using UnityEngine;

public class Ghost : LayerEventHandler
{
    public float AlphaWhenGhost = 0.5f;

    public override void OnLayerEnabled()
    {
        Color materialColor = gameObject.renderer.material.color;
        materialColor.a = 1.0f;
        gameObject.renderer.material.color = materialColor;

        gameObject.collider.enabled = true;
    }

    public override void OnLayerDisabled()
    {
        Color materialColor = gameObject.renderer.material.color;
        materialColor.a = AlphaWhenGhost;
        gameObject.renderer.material.color = materialColor;

        gameObject.collider.enabled = false;
    }
}