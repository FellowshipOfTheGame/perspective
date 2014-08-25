using UnityEngine;
using System.Collections;

public class LayerSwitchTimer : MonoBehaviour
{
    public float timerDelayInSeconds = 1.0f;
    public DualLayer[] DualLayers;
    private float lastTimeChange;
    private int index;

	// Use this for initialization
    //void Start ()
    //{
    //    lastTimeChange = Time.realtimeSinceStartup;
    //    foreach (DualLayer layer in DualLayers)
    //        layer.LayerEnabled = false;
    //    index = 0;
    //    if (DualLayers.Length != 0)
    //        DualLayers[index].LayerEnabled = true;
    //}
	
    //// Update is called once per frame
    //void Update ()
    //{
    //    if (DualLayers.Length < 2 || (Time.realtimeSinceStartup - lastTimeChange) < timerDelayInSeconds)
    //        return;
    //    int nextIndex;

    //    nextIndex = (index + 1) % DualLayers.Length;

    //    DualLayers[index].LayerEnabled = false;
    //    DualLayers[nextIndex].LayerEnabled = true;

    //    index = nextIndex;
    //    lastTimeChange = Time.realtimeSinceStartup;
    //}
}
