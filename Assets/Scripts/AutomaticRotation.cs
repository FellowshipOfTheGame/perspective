using UnityEngine;

public class AutomaticRotation : MonoBehaviour
{
    public Vector3 Velocity = Vector3.up;

    private void FixedUpdate()
    {
        transform.Rotate(Velocity, Space.World);
    }
}