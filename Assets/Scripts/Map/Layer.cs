using System;
using UnityEngine;

public class Layer : MonoBehaviour
{
    public bool LayerEnabled = true;
    private bool _internallyEnabled;

    public void Start()
    {
        DoToggle();
    }

    public void Update()
    {
        if (LayerEnabled != _internallyEnabled)
        {
            DoToggle();
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