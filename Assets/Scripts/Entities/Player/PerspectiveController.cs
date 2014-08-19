using UnityEngine;

public class PerspectiveController : MonoBehaviour
{
    public Layer TestLayer;

    public void Update()
    {
        if (Input.GetButtonDown("Next") || Input.GetButtonDown("Previous"))
        {
            TestLayer.LayerEnabled = !TestLayer.LayerEnabled;
        }
    }
}
