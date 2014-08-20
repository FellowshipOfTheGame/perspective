using System;
using UnityEngine;

public class Layer : MonoBehaviour
{
    public void Start()
    {
        foreach (PerspectiveResponse responses in GetComponentsInChildren<PerspectiveResponse>())
        {
            _deactivateAllEvent += responses.DeactivatePerspective;
            _activateAllEvent += responses.ActivatePerspective;
        }
    }

    public void ActivateAll()
    {
        if (_activateAllEvent != null)
        {
            _activateAllEvent();
        }
    }

    public void DeactivateAll()
    {
        if (_deactivateAllEvent != null)
        {
            _deactivateAllEvent();
        }
    }

    public void SetAllActive(bool active)
    {
        if (active)
        {
            _activateAllEvent();
        }
        else
        {
            _deactivateAllEvent();
        }
    }

    private event Action _activateAllEvent;
    private event Action _deactivateAllEvent;
}