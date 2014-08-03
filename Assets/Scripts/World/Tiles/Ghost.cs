using UnityEngine;

public class Ghost : LayerEventHandler
{
    public float ghostOpactity = 0.5f;

    public override void OnLayerEnabled()
    {
        Color newColor = gameObject.renderer.sharedMaterial.color;
        newColor.a = 1.0f;
        gameObject.renderer.sharedMaterial.color = newColor;
        
        gameObject.collider.enabled = true;

#if UNITY_EDITOR
        if (!Application.isPlaying)
        {
            newColor.a = ghostOpactity;
            gameObject.renderer.sharedMaterial.color = newColor;
        }
#endif
    }

    public override void OnLayerDisabled()
    {
        Color newColor = gameObject.renderer.sharedMaterial.color;
        newColor.a = ghostOpactity;
        gameObject.renderer.sharedMaterial.color = newColor;

        gameObject.collider.enabled = false;
    }
}