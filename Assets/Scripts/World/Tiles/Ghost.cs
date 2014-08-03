using UnityEngine;

public class Ghost : LayerEventHandler
{
    public float AlphaWhenGhost = 0.5f;

    public override void OnLayerEnabled()
    {
        Color materialColor = gameObject.renderer.sharedMaterial.color;
        materialColor.a = 1.0f;
        gameObject.renderer.sharedMaterial.color = materialColor;
        
        gameObject.collider.enabled = true;

#if UNITY_EDITOR
        if (!Application.isPlaying)
        {
            materialColor.a = AlphaWhenGhost;
            gameObject.renderer.sharedMaterial.color = materialColor;
        }
#endif
    }

    public override void OnLayerDisabled()
    {
        Color materialColor = gameObject.renderer.sharedMaterial.color;
        materialColor.a = AlphaWhenGhost;
        gameObject.renderer.sharedMaterial.color = materialColor;

        gameObject.collider.enabled = false;
    }
}