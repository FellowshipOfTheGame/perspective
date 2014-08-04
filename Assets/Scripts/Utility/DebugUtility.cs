using UnityEngine;

public static class DebugUtility
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void DrawRay(Vector3 origin, Vector3 direction, Color color)
    {
        Debug.DrawRay(origin, direction, color, 0f, true);
    }
}