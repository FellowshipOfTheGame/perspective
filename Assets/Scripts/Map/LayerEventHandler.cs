using UnityEngine;

[ExecuteInEditMode]
public abstract class LayerEventHandler : MonoBehaviour
{
    public void Awake()
    {
        Layer layer = GetComponentInParent<Layer>();
        layer.OnLayerEnabled += OnLayerEnabled;
        layer.OnLayerDisabled += OnLayerDisabled;
#if UNITY_EDITOR
        if (!Application.isPlaying)
        {
            Material material = new Material(gameObject.renderer.sharedMaterial)
            {
                color = EditorTint
            };
            gameObject.renderer.sharedMaterial = material;
        }
#endif
    }

    protected abstract void OnLayerEnabled();
    protected abstract void OnLayerDisabled();

    protected abstract Color EditorTint { get; }
}
