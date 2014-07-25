using UnityEngine;

public abstract class LayerObject : MonoBehaviour
{
    private Layer _layer;

    public void Awake()
    {
        _layer = GetComponentInParent<Layer>();
    }

    protected virtual void OnLayerEnabled() {}
    protected virtual void OnLayerDisabled() {}

    protected void RegisterLayerEnabledListener()
    {
        _layer.OnLayerEnabled += OnLayerEnabled;
    }

    protected void RegisterLayerDisabledListener()
    {
        _layer.OnLayerDisabled += OnLayerDisabled;
    }
}
