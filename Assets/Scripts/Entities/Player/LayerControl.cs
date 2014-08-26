using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LayerControl : MonoBehaviour
{
    private bool _isTransitioning;

    [SerializeField]
    public int LayerID;

    private SphereCollider _trigger;
    public float TransitionRadius = 25f;
    public float TransitionTime = 1f;

    public void Start()
    {
        _trigger = gameObject.AddComponent<SphereCollider>();
        _trigger.isTrigger = true;
        _trigger.radius = 0f;
        _trigger.enabled = false;
        Camera.main.backgroundColor = Map.Instance.DualLayers[LayerID].Sky;
    }

    public void Update()
    {
        if (Input.GetButtonDown("Next") && !_isTransitioning)
        {
            int nextLayerID = (LayerID + 1)%Map.Instance.DualLayers.Length;

            StartCoroutine(Transition(LayerID, nextLayerID));
            LayerID = nextLayerID;
        }

        if (Input.GetButtonDown("Previous") && !_isTransitioning)
        {
            int nextLayerID = (LayerID - 1);
            if (nextLayerID < 0)
            {
                nextLayerID += Map.Instance.DualLayers.Length;
            }

            StartCoroutine(Transition(LayerID, nextLayerID));
            LayerID = nextLayerID;
        }
    }

    public IEnumerator Transition(int previousLayer, int nextLayerID)
    {
        _isTransitioning = true;
        foreach (Dual dual in Map.Instance.DualLayers[previousLayer].Duals)
        {
            dual.Trigger.enabled = true;
        }

        foreach (Dual dual in Map.Instance.DualLayers[nextLayerID].Duals)
        {
            dual.Trigger.enabled = true;
        }

        Rigidbody rigidbody = this.rigidbody;
        float progress = 0f;
        _trigger.enabled = true;
        do
        {
            progress += Time.deltaTime;

            Camera.main.backgroundColor = 
                Color.Lerp(
                Map.Instance.DualLayers[previousLayer].Sky, 
                Map.Instance.DualLayers[nextLayerID].Sky, 
                progress);

            _trigger.radius = Mathf.Lerp(0f, TransitionRadius, progress);
            rigidbody.MovePosition(rigidbody.position + Vector3.up*1e-2f);
            yield return new WaitForFixedUpdate();

        } while (progress < 1f);
        _trigger.enabled = false;

        foreach (Dual dual in Map.Instance.DualLayers[previousLayer].Duals)
        {
            dual.IsReal = false;
            dual.Trigger.enabled = false;
        }

        foreach (Dual dual in Map.Instance.DualLayers[nextLayerID].Duals)
        {
            dual.IsReal = true; 
            dual.Trigger.enabled = false;
        }

        _isTransitioning = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        Dual dual = other.gameObject.GetComponent<Dual>();
        if (dual != null && other.isTrigger)
        {
            dual.IsReal = !dual.IsReal;
            dual.Trigger.enabled = false;
        }
    }
}