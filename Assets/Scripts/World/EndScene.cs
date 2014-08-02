using System.Collections;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
[RequireComponent(typeof (Collider))]
public class EndScene : MonoBehaviour
{
    public string NextScene;
    public float FadeOutTime;
    public Color FadeOutColor;
    private bool _isEnding;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            _isEnding = true;
            StartCoroutine(FadeScene());
        }
        
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            _isEnding = false;
        }
    }

    public IEnumerator FadeScene()
    {
        yield return new WaitForSeconds(FadeOutTime);

        if (_isEnding)
        {
            Application.LoadLevel(NextScene);
        }
    }

    
}