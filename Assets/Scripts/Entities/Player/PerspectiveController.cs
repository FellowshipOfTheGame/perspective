using System.Collections;
using UnityEngine;

public class PerspectiveController : MonoBehaviour
{
    public Layer[] Layers;

    public float FinalRadius = 10f;
    public float GrowthTime = 2f;

    public void Update()
    {
        if (Input.GetButtonDown("Next"))
        {
            StartCoroutine(GrowTrigger());
        }

        if (Input.GetButtonDown("Previous"))
        {
            
        }
    }

    public IEnumerator GrowTrigger()
    {
        SphereCollider trigger = gameObject.AddComponent<SphereCollider>();
        trigger.isTrigger = true;
        float progress = 0f;
        while (progress < 1f)
        {
            trigger.radius = Mathf.Lerp(0f, FinalRadius, progress);
            progress += Time.deltaTime/GrowthTime;
            Debug.Log(progress);
            yield return null;
        }

        Destroy(trigger);
    }

    public void OnTriggerEnter(Collider other)
    {
        PerspectiveResponse response = other.gameObject.GetComponent<PerspectiveResponse>();
        if (response != null)
        {
            response.PerspectiveActive = false;
        }
    }
}
