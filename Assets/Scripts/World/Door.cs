using UnityEngine;
using System.Collections;

public class Door : KeyEventHandler {

    public AudioClipArray AudioClip;
    public Material DoorMaterialOpen;
    private bool DoorOpen = false;

    public string NextScene;
    public float FadeOutTime = 1f;
    public Color FadeOutColor = Color.black;
    private bool _isEnding;
    public override void OnKeyAcquired()
    {
        DoorOpen = true;
        AudioClip.PlayRandomAtPoint(transform.position);
        foreach (Transform child in transform)
        {
            if(child.name.CompareTo("Handle") == 0)
            {
                child.GetComponent<MeshRenderer>().enabled = false;
                break;
            }
            else if(child.name.CompareTo("Door") == 0)
            {
                child.renderer.sharedMaterial = DoorMaterialOpen;
            }
        }
    }


    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && DoorOpen)
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
