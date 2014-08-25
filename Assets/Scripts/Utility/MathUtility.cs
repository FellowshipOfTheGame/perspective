using UnityEngine;
using System.Collections;

public class MathUtility
{
    public static float SqrDistance(Vector3 a, Vector3 b)
    {
        return (a.x - b.x) * (a.x - b.x) +
                (a.y - b.y) * (a.y - b.y) +
                (a.z - b.z) * (a.z - b.z);
    }

    public static Vector3 SmoothStep(Vector3 from, Vector3 to, float t)
    {
        Vector3 result;
        result.x = Mathf.SmoothStep(from.x, to.x, t);
        result.y = Mathf.SmoothStep(from.y, to.y, t);
        result.z = Mathf.SmoothStep(from.z, to.z, t);

        return result;
    }
}
