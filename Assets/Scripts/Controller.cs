using UnityEngine;

public class Controller : MonoBehaviour
{
    public float AccelerationOnGround = 100f;
    public float MaxVelocityOnGround = 50f;

    public float JumpHeight = 2.01f;
    public float AccelerationOnAir = 15f;
    //public float MaxVelocityOnAir = 10f;

    private bool _isGrounded;
    

    public void FixedUpdate()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, collider.bounds.extents.y);

        float acceleration;
        float maxVelocity;
        Vector3 velocity = rigidbody.velocity;
        if (_isGrounded)
        {
            acceleration = AccelerationOnGround;
            maxVelocity = MaxVelocityOnGround;

            if (Input.GetButton("Jump"))
            {
                velocity.y = Mathf.Sqrt(-2f * Physics.gravity.y * JumpHeight);
            }
        }
        else
        {
            acceleration = AccelerationOnAir;
            maxVelocity = Mathf.Infinity;
        }

        float horizontalInput = Input.GetAxis("Horizontal");

        bool pathBlocked = Physics.Raycast(
            origin: transform.position, 
            direction: Mathf.Sign(horizontalInput)*Vector3.right,
            distance: collider.bounds.extents.x);
        
        if (!pathBlocked)
        {
            rigidbody.AddForce(horizontalInput*acceleration*Vector3.right);
            velocity.x = Mathf.Clamp(velocity.x, -maxVelocity, maxVelocity);
        }

        rigidbody.velocity = velocity;
    }
    
}