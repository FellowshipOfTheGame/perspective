using UnityEngine;
using System.Collections;

public class Door : KeyEventHandler {
    public AudioClipArray AudioClip;
    public Material DoorOpenMaterial;
    private bool IsDoorOpen = false;
    public string NextScene;
    public float FadeOutTime = 1f;
    public Color FadeOutColor = Color.black;
    private bool _isEnding;

    public override void OnKeyAcquired()
    {
        AudioClip.PlayRandomAtPoint(transform.position);
        foreach (Transform child in transform)
        {
            if(child.name == "Handle")
            {
                DestroyObject(child);
            }
            else if(child.name == "Door")
            {
                child.renderer.sharedMaterial = DoorOpenMaterial;
                IsDoorOpen = true;
            }
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && IsDoorOpen)
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
