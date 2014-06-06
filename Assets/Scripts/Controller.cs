using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Controller : MonoBehaviour
{
    public void Awake()
    {
        _groundRay = new Ray { direction = Vector3.down };
    }

    public void FixedUpdate()
    {
        Vector2 inputAxes = new Vector2(
            x: Input.GetAxisRaw("Horizontal"),
            y: Input.GetAxisRaw("Vertical"));

        #region Ground Check

        _groundRay.origin = transform.position + Vector3.down * (collider.bounds.extents.y - .5f * GroundRaySize);
        _isGrounded = Physics.Raycast(_groundRay, GroundRaySize);

        #endregion Ground Check

        #region Kinematics

        float horizontalVelocity = rigidbody.velocity.x + (inputAxes.x * Acceleration);
        horizontalVelocity = Mathf.Clamp(horizontalVelocity, -MaximumSpeed, +MaximumSpeed);
        rigidbody.velocity = new Vector3(horizontalVelocity, rigidbody.velocity.y, rigidbody.velocity.z);
        
        if (_isGrounded)
        {
            if (inputAxes.y > 0f)
            {
                rigidbody.AddForce(Vector3.up * JumpImpulse, ForceMode.Impulse);
            }
        }

        #endregion Kinematics

        #region Animation
        if (_isGrounded)
        {
            animation.CrossFade(Mathf.Abs(inputAxes.x) > 0f ? "run" : "idle");
        }
        //else
        //{
        //    //Jump
        //}

        if (inputAxes.x > 0)
        {
            transform.rotation = _facingRightRotation;
        }
        else if (inputAxes.x < 0)
        {
            transform.rotation = _facingLeftRotation;
        }
        #endregion Animation
    }

    void OnDrawGizmos()
    {
        //GroundCheck
        Gizmos.DrawRay(_groundRay.origin, Vector3.down * GroundRaySize);

        //Velocity
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, rigidbody.velocity/MaximumSpeed);
    }

    #region Ground Check
    private Ray _groundRay;
    private bool _isGrounded;
    private const float GroundRaySize = .05f;
    #endregion GroundCheck

    #region Kinematics
    public float Acceleration = 5f;
    public float MaximumSpeed = 20f;
    public float JumpImpulse = 10f;
    #endregion Kinematics

    #region Constants
    private readonly Quaternion _facingRightRotation = Quaternion.Euler(0, 90, 0);
    private readonly Quaternion _facingLeftRotation = Quaternion.Euler(0, 270, 0);
    #endregion Constants
}
