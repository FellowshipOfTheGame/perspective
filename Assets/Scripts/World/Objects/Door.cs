using UnityEngine;
using System.Collections;

public class Door : KeyEventHandler {
    public bool IsOpen;
    
    public string NextScene;
    public float FadeOutTime = 1f;
    public Color FadeOutColor = Color.black;
    public AudioClipArray AudioClip;
    private bool _isEnding;

    public override void OnKeyAcquired()
    {
        AudioClip.PlayRandomAtPoint(transform.position);
        foreach (Transform child in transform)
        {
            if(child.name == "Handle")
            {
                DestroyObject(child.gameObject);
            }
            else if(child.name == "Door")
            {
                IsOpen = true;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && IsOpen)
        {
            _isEnding = true;
            StartCoroutine(FadeScene());
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
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
