using UnityEngine;

public class Ghost : PerspectiveResponse
{
    public float AlphaWhenGhost = 0.5f;


    public override void OnPerspectiveEnabled()
    {
        Color materialColor = gameObject.renderer.material.color;
        materialColor.a = 1.0f;
        gameObject.renderer.material.color = materialColor;

        Collider collider = gameObject.collider;
        if (collider != null)
        {
            gameObject.collider.enabled = true;
        }
    }

    public override void OnPerspectiveDisabled()
    {
        Color materialColor = gameObject.renderer.material.color;
        materialColor.a = AlphaWhenGhost;
        gameObject.renderer.material.color = materialColor;

        Collider collider = gameObject.collider;
        if (collider != null)
        {
            gameObject.collider.enabled = false;
        }
    }
}