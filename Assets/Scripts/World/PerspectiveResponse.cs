using UnityEngine;

public abstract class PerspectiveResponse : MonoBehaviour
{
    [SerializeField] private bool _perspectiveActive = true;

    public bool PerspectiveActive
    {
        get { return _perspectiveActive; }
        set
        {
            if (value)
            {
                OnPerspectiveActivated();
            }
            else
            {
                OnPerspectiveDeactivated();
            }

            _perspectiveActive = value;
        }
    }

    public void Start()
    {
        PerspectiveActive = _perspectiveActive;
    }

    protected abstract void OnPerspectiveActivated();
    protected abstract void OnPerspectiveDeactivated();
}