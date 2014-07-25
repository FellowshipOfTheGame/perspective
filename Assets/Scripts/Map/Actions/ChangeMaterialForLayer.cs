using UnityEngine;

public class ChangeMaterialForLayer : LayerObject
{
    public Material MaterialWhenEnabled;
    public Material MaterialWhenDisabled;

    public void Start()
    {
        RegisterLayerEnabledListener();
        RegisterLayerDisabledListener();
    }

    protected override void OnLayerEnabled()
    {
        base.OnLayerEnabled();
        gameObject.renderer.material = MaterialWhenEnabled;
    }

    protected override void OnLayerDisabled()
    {
        base.OnLayerDisabled();
        gameObject.renderer.material = MaterialWhenDisabled;
    }
}
