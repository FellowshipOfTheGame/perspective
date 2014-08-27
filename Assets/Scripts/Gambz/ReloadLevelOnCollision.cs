using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class ReloadLevelOnCollision : MonoBehaviour {

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collision.collider.isTrigger)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

}
