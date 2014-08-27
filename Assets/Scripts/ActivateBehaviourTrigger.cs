using System.Collections;
using UnityEngine;

[RequireComponent(typeof (Collider))]
public class ActivateBehaviourTrigger : MonoBehaviour
{
    public float Delay = 1f;
    public string Component;
    public GameObject[] Targets;

    private bool _playerIsTouching;

    public void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger && other.gameObject.CompareTag("Player"))
        {
            _playerIsTouching = true;
            StartCoroutine(WaitAndActivate());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        _playerIsTouching = false;
    }

    private IEnumerator WaitAndActivate()
    {
        yield return new WaitForSeconds(Delay);

        if (_playerIsTouching)
        {
            foreach (GameObject target in Targets)
            {
                MonoBehaviour behaviour = (target.GetComponent(Component) as MonoBehaviour);
                if (behaviour != null)
                {
                    behaviour.enabled = true;
                }
            }
            collider.enabled = false;
        }
    }
}