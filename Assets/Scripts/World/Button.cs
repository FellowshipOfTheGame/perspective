using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
[RequireComponent(typeof (Collider))]
public class Button : MonoBehaviour
{
    public ButtonResponse[] Responses;

    public void OnCollisionEnter(Collision collision)
    {
        foreach (ButtonResponse response in Responses)
        {
            if (response != null)
            {
                response.OnButtonDown(collision.gameObject);
            }
        }

        gameObject.renderer.material.color = new Color(1f, 0f, 0f);
    }

    public void OnCollisionExit(Collision collision)
    {
        foreach (ButtonResponse response in Responses)
        {
            if (response != null)
            {
                response.OnButtonUp(collision.gameObject);
            }
        }

        gameObject.renderer.material.color = new Color(.5f, 0f, 0f);
    }
}