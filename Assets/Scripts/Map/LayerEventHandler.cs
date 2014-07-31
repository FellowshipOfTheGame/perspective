using UnityEngine;


public abstract class LayerEventHandler : MonoBehaviour
{
    public abstract void OnLayerEnabled();
    public abstract void OnLayerDisabled();
}
