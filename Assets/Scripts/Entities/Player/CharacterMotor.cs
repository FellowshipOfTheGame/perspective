using System;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
[RequireComponent(typeof (Collider))]
[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (SpriteRenderer))]
public class CharacterMotor : MonoBehaviour
{
    public float AccelerationOnGround = 100f;
    public float MaxHorizontalVelocity = 50f;

    public float TurningSpeed = 3;

    public float JumpHeight = 2.01f;
    public float AccelerationOnAir = 15f;

    private bool _isGrounded;

    private Animator _animator;
    private Vector3 _colliderCenter;

    public AudioClipArray JumpAudio;

    public void Awake()
    {
        _animator = GetComponent<Animator>();
        _colliderCenter = ((CapsuleCollider) collider).center;
    }

    public void FixedUpdate()
    {
        RaycastHit hit;
        _isGrounded = Physics.Raycast(
            transform.position + _colliderCenter,
            Vector3.down,
            out hit,
            collider.bounds.extents.y);

        if (_isGrounded)
        {
            _isGrounded &= !hit.collider.isTrigger;
        }

        float acceleration = _isGrounded ? AccelerationOnGround : AccelerationOnAir;

        float horizontalInput = Input.GetAxis("Horizontal");

        if (Math.Abs(horizontalInput) > .01f)
        {
            bool pathBlocked = Physics.Raycast(
                origin: transform.position + _colliderCenter,
                direction: Mathf.Sign(horizontalInput)*Vector3.right,
                distance: collider.bounds.extents.y + .01f);

            if (!pathBlocked)
            {
                rigidbody.AddForce(horizontalInput*acceleration*Vector3.right);
            }
        }

        Vector3 velocity = rigidbody.velocity;

        if (_isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                velocity.y = Mathf.Sqrt(-2f*Physics.gravity.y*JumpHeight);
                JumpAudio.PlayRandomAtPoint(transform.position);
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

        _animator.SetFloat("speed", Mathf.Abs(velocity.x * horizontalInput));
        _animator.SetBool("grounded", _isGrounded);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + ((CapsuleCollider) collider).center, Vector3.down*collider.bounds.extents.y);
    }
}