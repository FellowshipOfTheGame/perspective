using System;
using UnityEngine;

public class Layer : MonoBehaviour
{
    [SerializeField]
    private bool _layerEnabled = true;

    public bool LayerEnabled
    {
        get { return _layerEnabled; }
        set
        {
            _layerEnabled = value;
            ToggleFullLayer();
        }
    }

    public void Start()
    {
        foreach (PerspectiveResponse eventHandler in GetComponentsInChildren<PerspectiveResponse>())
        {
            OnFullLayerDisabled += eventHandler.OnPerspectiveDisabled;
            OnFullLayerEnabled += eventHandler.OnPerspectiveEnabled;
        }

        ToggleFullLayer();
    }

    private void ToggleFullLayer()
    {
        if (LayerEnabled)
        {
            if (OnFullLayerEnabled != null)
            {
                OnFullLayerEnabled();
            }
        }
        else
        {
            if (OnFullLayerDisabled != null)
            {
                OnFullLayerDisabled();
            }
        }

        _layerEnabled = LayerEnabled;
    }

    public event Action OnFullLayerEnabled;
    public event Action OnFullLayerDisabled;
}