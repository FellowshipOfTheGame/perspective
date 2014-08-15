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
}
