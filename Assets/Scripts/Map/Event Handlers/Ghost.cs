using UnityEngine;

public class Ghost : LayerEventHandler
{
    public Material MaterialWhenEnabled;
    public Material MaterialWhenDisabled;

    protected override void OnLayerEnabled()
    {
        gameObject.renderer.material = MaterialWhenEnabled;
        gameObject.collider.enabled = true;
    }

    protected override void OnLayerDisabled()
    {
        gameObject.renderer.material = MaterialWhenDisabled;
        gameObject.collider.enabled = false;
    }

    protected override Color EditorTint
    {
        get { return new Color(.5f, .5f, 1f, .5f); }
    }
}
