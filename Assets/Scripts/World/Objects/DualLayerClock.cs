using UnityEngine;

public class DualLayerClock : MonoBehaviour
{
    public float Period = 1f;

    private float _lastChangeTime;
    private int _layerID;

    public AudioClipArray TransitionSound;

    public void Start()
    {
        _lastChangeTime = Time.time;
    }

    public void Update()
    {
        if (Time.time - _lastChangeTime >= Period)
        {
            TransitionSound.PlayRandomAtPoint(GameObject.FindGameObjectWithTag("Player").transform.position);
            _lastChangeTime = Time.time;
            int nextLayerID = (_layerID + 1)%Map.Instance.DualLayers.Length;
            foreach (Dual dual in Map.Instance.DualLayers[nextLayerID].Duals)
            {
                dual.IsReal = true;
            }
            foreach (Dual dual in Map.Instance.DualLayers[_layerID].Duals)
            {
                dual.IsReal = false;
            }

            _layerID = nextLayerID;
        }
    }
}