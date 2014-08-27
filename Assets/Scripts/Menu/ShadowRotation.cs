using UnityEngine;
using System.Collections;

public class ShadowRotation : MonoBehaviour
{
    public float Sensibility = 5.0f;
    private Vector3 OriginalVector;

    void Start()
    {
        OriginalVector = transform.rotation.eulerAngles;
    }

	void Update ()
    {
        float differenceX = 1 - 2 * Input.mousePosition.x / Screen.width;
        float differenceY = 1 - 2 * Input.mousePosition.y / Screen.height;

        transform.rotation = Quaternion.Euler(new Vector3(
            x: OriginalVector.x + differenceY * Sensibility,
            y: OriginalVector.y + differenceX * Sensibility,
            z: OriginalVector.z));
	}
}
