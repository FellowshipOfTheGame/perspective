using UnityEngine;
using System.Collections;

public class ShadowRotation : MonoBehaviour
{
    public float Sensibility = 5.0f;

	void Update ()
    {
        float differenceX = 1 - 2 * Input.mousePosition.x / Screen.width;
        float differenceY = 1 - 2 * Input.mousePosition.y / Screen.height;

        transform.rotation = Quaternion.Euler(new Vector3(
            x: differenceY * Sensibility,
            y: 180 + differenceX * Sensibility,
            z: 0));
	}
}
