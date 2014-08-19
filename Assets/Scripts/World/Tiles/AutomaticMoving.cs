using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public class AutomaticMoving : MonoBehaviour
{
    public Vector3 Offset = Vector3.right;
    public float Period = 1f;

    private Vector3 _startingPosition;
    private float _epsilon = 0f;
    private int _signal = 1;

    public void Start()
    {
        _startingPosition = transform.position;
    }

    public void FixedUpdate()
    {
        _epsilon += _signal*(Time.fixedDeltaTime/Period);
        if (_epsilon >= 1f)
        {
            _epsilon = 1f;
            _signal *= -1;
        }
        else if (_epsilon <= 0f)
        {
            _epsilon = 0f;
            _signal *= -1;
        }

        rigidbody.MovePosition(Vector3.Lerp(_startingPosition, _startingPosition + Offset, _epsilon));
    }
}