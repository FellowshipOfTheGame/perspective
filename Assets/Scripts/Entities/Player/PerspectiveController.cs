using System.Collections;
using UnityEngine;

public class PerspectiveController : MonoBehaviour
{
    //public Layer[] Layers;

    //public float FinalRadius = 10f;
    //public float GrowthTime = 2f;

    //private int _currentLayerID;
    //private bool _isGrowing;

    //public void Update()
    //{
    //    if (Input.GetButtonDown("Next") && !_isGrowing)
    //    {
    //        StartCoroutine(GrowTrigger(_currentLayerID, (_currentLayerID + 1)%Layers.Length));
    //    }

    //    if (Input.GetButtonDown("Previous") && !_isGrowing)
    //    {
    //        int nextLayerID = (_currentLayerID - 1);
    //        if (nextLayerID < 0)
    //        {
    //            nextLayerID += Layers.Length;
    //        }

    //        StartCoroutine(GrowTrigger(_currentLayerID, nextLayerID));
    //    }
    //}

    //public IEnumerator GrowTrigger(int currentLayerID, int nextLayerID)
    //{
    //    _isGrowing = true;

    //    Layers[currentLayerID].ActivateTriggers();
    //    Layers[nextLayerID].ActivateTriggers();

    //    SphereCollider trigger = gameObject.AddComponent<SphereCollider>();
    //    trigger.isTrigger = true;
    //    float progress = 0f;
    //    while (progress < 1f)
    //    {
    //        trigger.radius = Mathf.Lerp(0f, FinalRadius, progress);
    //        progress += Time.deltaTime/GrowthTime;
    //        yield return null;
    //    }

    //    Destroy(trigger);

    //    _isGrowing = false;

    //    Layers[_currentLayerID].DeactivatePerspective();
    //    Layers[nextLayerID].ActivatePerspective();
    //    _currentLayerID = nextLayerID;
    //}

    //public void OnTriggerEnter(Collider other)
    //{
    //    PerspectiveResponse response = other.gameObject.GetComponent<PerspectiveResponse>();
    //    if (response != null)
    //    {
    //        response.TogglePerspective();
    //    }
    //}
}