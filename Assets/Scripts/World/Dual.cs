using UnityEngine;

public abstract class Dual : MonoBehaviour
{
    [SerializeField]
    private bool _isReal = true;

    public bool IsReal
    {
        get { return _isReal; }
        set
        {
            if (value)
            {
                BecomeReal();
            }
            else
            {
                BecomeImaginary();
            }

            _isReal = value;
        }
    }

    [HideInInspector]
    public SphereCollider Trigger;

    protected abstract void BecomeReal();
    protected abstract void BecomeImaginary();

    public void Start()
    {
        Collider someCollider = GetComponent<Collider>();

        Trigger = gameObject.AddComponent<SphereCollider>();
        Trigger.enabled = false;
        Trigger.isTrigger = true;
        Trigger.radius = (someCollider != null) ? someCollider.bounds.size.x*.45f : .45f;

        IsReal = _isReal;
    }
}