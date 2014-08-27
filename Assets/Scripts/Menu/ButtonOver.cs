using UnityEngine;
using System.Collections;

public class ButtonOver : MonoBehaviour 
{
    public Vector3 ScaleMultiplier = new Vector3(1.5f, 1.0f, 1.5f);
    public float Delay = 2.0f;

    private Vector3 OriginalScale;
    private float BeginTime;
    private Vector3 NewScale;
    private bool IsMouseOver;
    void Start()
    {
        OriginalScale = transform.localScale;
        NewScale.x = OriginalScale.x * ScaleMultiplier.x;
        NewScale.y = OriginalScale.y * ScaleMultiplier.y;
        NewScale.z = OriginalScale.z * ScaleMultiplier.z;
    }

    IEnumerator Scale(Vector3 from, Vector3 to, bool ShouldBeScaling)
    {
        while ((Time.realtimeSinceStartup - BeginTime) < Delay && IsMouseOver == ShouldBeScaling)
        {
            transform.localScale = MathUtility.SmoothStep(from, to , (Time.realtimeSinceStartup - BeginTime) / Delay);
            yield return null;
        }
    }

    void OnMouseEnter()
    {
        BeginTime = Time.realtimeSinceStartup;
        IsMouseOver = true;
        StartCoroutine(Scale(OriginalScale, NewScale, true));
    }

    void OnMouseExit()
    {
        BeginTime = Time.realtimeSinceStartup;
        IsMouseOver = false;
        StartCoroutine(Scale(transform.localScale, OriginalScale, false));
    }
}
