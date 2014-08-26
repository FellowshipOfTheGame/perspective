using UnityEngine;

public class DualLayer : MonoBehaviour
{
    public Color Sky = Color.black;
    public Dual[] Duals { get; set; }

    public void Start()
    {
        Duals = GetComponentsInChildren<Dual>();
    }
}