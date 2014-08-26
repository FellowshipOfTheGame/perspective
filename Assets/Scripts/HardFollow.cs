using UnityEngine;

public class HardFollow : MonoBehaviour
{
    public Vector3 Distance = Vector3.back;
    public Transform Target;

    public void LateUpdate()
    {
        transform.position = Target.position + Distance;
    }
}
