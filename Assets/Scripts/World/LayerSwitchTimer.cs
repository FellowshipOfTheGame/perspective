using UnityEngine;
using System.Collections;

public class LayerSwitchTimer : MonoBehaviour
{
    public float timerDelayInSeconds = 1.0f;
    public Layer[] layers;
    private float lastTimeChange;
    private int index;

	// Use this for initialization
	void Start ()
    {
        lastTimeChange = Time.realtimeSinceStartup;
        foreach (Layer layer in layers)
            layer.LayerEnabled = false;
        index = 0;
        if (layers.Length != 0)
            layers[index].LayerEnabled = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (layers.Length == 0 || (Time.realtimeSinceStartup - lastTimeChange) < timerDelayInSeconds)
            return;

        int nextIndex;
        nextIndex = (index + 1) % layers.Length;

        layers[index].LayerEnabled = false;
        layers[nextIndex].LayerEnabled = true;

        index = nextIndex;
        lastTimeChange = Time.realtimeSinceStartup;
	}
}
