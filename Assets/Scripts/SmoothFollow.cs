using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    public Transform Target
    {
        get { return _target; }
        set
        {
            _target = value;
            _targetRigidbody = _target.rigidbody;
            _targetMotor = _target.GetComponent<CharacterMotor>();
            _ahead = Vector3.zero;
            _velocity = Vector3.zero;
        }
    }

    public Vector3 Distance = 2f * Vector3.back;
    public float SmoothTime = .1f;
    public float HorizontalAheadOfTime = 2f;

    private Vector3 _velocity;
    private Vector3 _ahead;

    private Rigidbody _targetRigidbody;
    private CharacterMotor _targetMotor;

    public void LateUpdate()
    {
        _ahead =
            Vector3.SmoothDamp(_ahead,
                Vector3.right*HorizontalAheadOfTime*_targetRigidbody.velocity.x/_targetMotor.MaxHorizontalVelocity,
                ref _velocity,
                SmoothTime*Time.deltaTime);

        transform.position = Vector3.SmoothDamp(
            transform.position,
            Target.transform.position + Distance + _ahead,
            ref _velocity,
            SmoothTime*Time.deltaTime);
    }
}