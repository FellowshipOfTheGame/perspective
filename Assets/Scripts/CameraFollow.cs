using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;

    public Vector2 Distance = new Vector2(0f, 1f);
    public Vector2 Margin = Vector2.one;
    public Vector2 Minimum = new Vector2(-100f, -100f);
    public Vector2 Maximum = new Vector2(100f, 100f);
    public float SmoothTime = 10f;

    public void LateUpdate()
    {
        Vector3 position = transform.position;
        if (Mathf.Abs(position.x - (Target.position.x + Distance.x)) > Margin.x)
        {
            position.x = Mathf.SmoothStep(
                from: position.x,
                to:Target.position.x + Distance.x,
                t:SmoothTime*Time.deltaTime);
        }
        if (Mathf.Abs(position.y - (Target.position.y + Distance.y)) > Margin.y)
        {
            position.y = Mathf.SmoothStep(
                from:position.y, 
                to:Target.position.y + Distance.y,
                t:SmoothTime*Time.deltaTime);
        }

        position.x = Mathf.Clamp(position.x, Minimum.x, Maximum.x);
        position.y = Mathf.Clamp(position.y, Minimum.y, Maximum.y);
        transform.position = position;
    }
}   