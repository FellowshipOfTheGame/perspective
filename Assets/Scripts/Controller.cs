using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Controller : MonoBehaviour {

    /// <summary>
    /// The speed.
    /// </summary>
	public float speed = 50f;

    public float jumpSpeed = 4f;

    /// <summary>
    /// The player is touching the ground.
    /// </summary>
    private bool isGrounded = false;

	public void FixedUpdate()
	{
        float inputHorizontal = Input.GetAxisRaw("Horizontal");

        rigidbody.AddForce(Vector3.right *  inputHorizontal * (speed * Time.deltaTime), ForceMode.VelocityChange);

        //Dat LULZ rotation
        Quaternion rotation = Quaternion.Euler(new Vector3(rigidbody.rotation.x, rigidbody.rotation.y, -inputHorizontal * 5f));
        rigidbody.rotation = rotation;

        if (isGrounded)
        {
            if(Input.GetAxisRaw("Vertical") == 1f)
            {
                rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
            }
        }

        isGrounded = false;
	}

    public void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }
}
