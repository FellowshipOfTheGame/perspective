using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 Distance = 2f*Vector3.back;
    public float SmoothTime = .2f;

    private Vector3 _velocity;

    public void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, Target.transform.position + Distance, ref _velocity, SmoothTime);
    }
}