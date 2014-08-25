using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Trinitrotoluene : ExplosionResponse
{
    public float Delay = 1f;
    public float Radius = 2f;

    public AudioClipArray ExplosionSounds;

    public GameObject ParticlesPrefab;

    private SphereCollider _trigger;

    public void Start()
    {
        _trigger = gameObject.AddComponent<SphereCollider>();
        _trigger.isTrigger = true;
        _trigger.radius = 0f;
        _trigger.enabled = false;
        rigidbody.WakeUp();
    }

    public override IEnumerator Explode()
    {
        HasExploded = true;
        float progress = 0f;
        _trigger.enabled = true;
        do
        {
            progress += Time.deltaTime;
            _trigger.radius = Mathf.Lerp(0f, Radius, progress);
            transform.localScale = MathUtility.SmoothStep(Vector3.one, Vector3.one*1.5f, 2*progress);
            rigidbody.MovePosition(rigidbody.position + Vector3.forward * 1e-5f);
            yield return new WaitForFixedUpdate();
        } while (progress < 1f);

        GameObject particles = (GameObject) GameObject.Instantiate(ParticlesPrefab);
        particles.transform.position = transform.position;
        ExplosionSounds.PlayRandomAtPoint(transform.position);

        _trigger.enabled = false;
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            ExplosionResponse response = GetComponent<ExplosionResponse>();
            if (response != null && !response.HasExploded)
            {
                StartCoroutine(GetComponent<ExplosionResponse>().Explode());
            }
        }
    }
}
