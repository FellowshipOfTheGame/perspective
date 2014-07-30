using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Animator))]
public class CharacterMotor : MonoBehaviour
{
    public float AccelerationOnGround = 100f;
    public float MaxHorizontalVelocity = 50f;

    public float JumpHeight = 2.01f;
    public float AccelerationOnAir = 15f;

    public float GroundDistance = .5f;

    private bool _isGrounded;
    public float TurningSpeed = 3;

    private Animator _animator;

    public void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void FixedUpdate()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, GroundDistance);

        float acceleration = _isGrounded ? AccelerationOnGround : AccelerationOnAir;

        float horizontalInput = Input.GetAxis("Horizontal");

        bool pathBlocked = Physics.Raycast(
            origin: transform.position,
            direction: Mathf.Sign(horizontalInput)*Vector3.right,
            distance: collider.bounds.extents.x);

        if (!pathBlocked)
        {
            rigidbody.AddForce(horizontalInput*acceleration*Vector3.right);
        }

        Vector3 velocity = rigidbody.velocity;

        if (_isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                velocity.y = Mathf.Sqrt(-2f*Physics.gravity.y*JumpHeight);
            }
        }

        velocity.x = Mathf.Clamp(velocity.x, -MaxHorizontalVelocity, MaxHorizontalVelocity);
        rigidbody.velocity = velocity;

        Vector3 euler = transform.rotation.eulerAngles;
        if (horizontalInput < 0f)
        {
            euler.y += 180f*Time.deltaTime*TurningSpeed;
        }
        else if (horizontalInput > 0f)
        {
            euler.y -= 180f*Time.deltaTime*TurningSpeed;
        }

        euler.y = Mathf.Clamp(euler.y, 0f, 180f);
        transform.rotation = Quaternion.Euler(euler);

        _animator.SetFloat("speed", Mathf.Abs(velocity.x));
        _animator.SetBool("grounded", _isGrounded);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * GroundDistance);
    }
}