using UnityEngine;

public class DualLayer : MonoBehaviour
{
    public Dual[] Duals { get; set; }

    public void Start()
    {
        Duals = GetComponentsInChildren<Dual>();
    }
}