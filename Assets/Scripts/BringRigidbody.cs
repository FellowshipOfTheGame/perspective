using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
[RequireComponent(typeof (Collider))]
public class BringRigidbody : MonoBehaviour
{
    private Rigidbody _collidingbody;
    private Vector3 _lastPosition;

    public void Start()
    {
        _lastPosition = transform.position;
    }

    public void FixedUpdate()
    {
        if (_collidingbody != null)
        {
            Vector3 delta = transform.position - _lastPosition;
            _collidingbody.MovePosition(_collidingbody.position + delta);
        }

        _lastPosition = transform.position;
        _collidingbody = null;
    }

    public void OnCollisionStay(Collision collision)
    {
        if (_collidingbody == null && collision.rigidbody != null)
        {
            _collidingbody = collision.rigidbody;
        }
    }
}