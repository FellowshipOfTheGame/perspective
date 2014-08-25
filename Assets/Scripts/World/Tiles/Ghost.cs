using UnityEngine;

public class Ghost : Dual
{
    public float AlphaWhenGhost = 0.5f;

    protected override void BecomeReal()
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

    protected override void BecomeImaginary()
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