using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
[RequireComponent(typeof (Collider))]
public class Kill : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        Death death = collision.gameObject.GetComponent<Death>();
        if (death != null)
        {
            death.OnDeath();
        }
    }
}