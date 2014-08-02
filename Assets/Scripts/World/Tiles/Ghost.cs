using UnityEngine;

public class Ghost : LayerEventHandler
{
    public Material MaterialWhenEnabled;
    public Material MaterialWhenDisabled;


    public override void OnLayerEnabled()
    {
        gameObject.renderer.material = MaterialWhenEnabled;
        gameObject.collider.enabled = true;

#if UNITY_EDITOR
        if (!Application.isPlaying)
        {
            gameObject.renderer.material = MaterialWhenDisabled;
        }
#endif
    }

    public override void OnLayerDisabled()
    {
        gameObject.renderer.material = MaterialWhenDisabled;
        gameObject.collider.enabled = false;
    }
}