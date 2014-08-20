using UnityEngine;

public class Layer : MonoBehaviour
{
    public PerspectiveResponse[] Responses { get; set; }
    public void Start()
    {
        Responses = GetComponentsInChildren<PerspectiveResponse>();
    }
}