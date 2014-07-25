public class DisableCollisionForLayer : LayerObject
{
    public void Start()
    {
        RegisterLayerEnabledListener();
        RegisterLayerDisabledListener();
    }

    protected override void OnLayerEnabled()
    {
        base.OnLayerEnabled();
        gameObject.collider.enabled = true;
    }

    protected override void OnLayerDisabled()
    {
        base.OnLayerDisabled();
        gameObject.collider.enabled = false;
    }
}