using UnityEngine;

public class LayerController : MonoBehaviour
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
