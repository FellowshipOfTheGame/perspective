using System.Collections;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
[RequireComponent(typeof (BringRigidbody))]
public class AutomaticMoving : MonoBehaviour
{
    public Vector3 Offset = Vector3.right;
    public float Period = .5f;
    public float WaitSeconds = .5f;

    private Vector3 _startingPosition;
    private float _epsilon = 0f;
    private int _signal = 1;
    private bool _isWaiting = false;

    public void Start()
    {
        _startingPosition = transform.position;
    }

    public void FixedUpdate()
    {
        if (!_isWaiting)
        {
            _epsilon += _signal*(Time.fixedDeltaTime/Period);
            rigidbody.MovePosition(Vector3.Lerp(_startingPosition, _startingPosition + Offset, _epsilon));

            if (_epsilon >= 1f || _epsilon <= 0f)
            {
                _signal = -_signal;
                _epsilon = Mathf.Clamp01(_epsilon);
                _isWaiting = true;
                StartCoroutine(WaitToMove());
            }
        }
    }

    public IEnumerator WaitToMove()
    {
        yield return new WaitForSeconds(WaitSeconds);
        _isWaiting = false;
    }
}