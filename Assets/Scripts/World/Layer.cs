using System;
using UnityEngine;

//[ExecuteInEditMode]
public class Layer : MonoBehaviour
{
    public bool LayerEnabled = true;
    private bool _internallyEnabled;

    public void Start()
    {
        foreach (LayerEventHandler eventHandler in GetComponentsInChildren<LayerEventHandler>())
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                OnLayerDisabled -= eventHandler.OnLayerDisabled;
                OnLayerEnabled -= eventHandler.OnLayerEnabled;
            }
#endif
            OnLayerDisabled += eventHandler.OnLayerDisabled;
            OnLayerEnabled += eventHandler.OnLayerEnabled;
        }

        DoToggle();
    }

    public void Update()
    {
        if (LayerEnabled != _internallyEnabled)
        {
            DoToggle();
        }
    }
    public void RemoveEvents(GameObject obj)
    {
        foreach (LayerEventHandler eventHandler in obj.GetComponents<LayerEventHandler>())
        {
            OnLayerDisabled -= eventHandler.OnLayerDisabled;
            OnLayerEnabled -= eventHandler.OnLayerEnabled;
        }
    }

    private void DoToggle()
    {
        if (LayerEnabled)
        {
            if (OnLayerEnabled != null)
            {
                OnLayerEnabled();
            }
        }
        else
        {
            if (OnLayerDisabled != null)
            {
                OnLayerDisabled();
            }
        }

        _internallyEnabled = LayerEnabled;
    }

    public event Action OnLayerEnabled;
    public event Action OnLayerDisabled;
}