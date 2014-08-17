using UnityEngine;
using System.Collections;

public class Shadow : MonoBehaviour
{
    public float Sensibility = 1.0f;
    private Vector3 OriginalShadowPosition;
    public void Start()
    {
        OriginalShadowPosition = transform.position;
    }
    public void Update()
    {
        float differenceX = 1 - 2 * Input.mousePosition.x / Screen.width;
        float differenceY = 1 - 2 * Input.mousePosition.y / Screen.height;
        transform.position = new Vector3(
            x: OriginalShadowPosition.x + differenceX * Sensibility,
            y: OriginalShadowPosition.y + differenceY * Sensibility,
            z: OriginalShadowPosition.z);
    }
}
