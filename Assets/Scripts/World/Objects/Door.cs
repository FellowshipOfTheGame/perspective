using UnityEngine;
using System.Collections;

public class Door : KeyEventHandler {
    public bool IsOpen;
    
    public string NextScene;
    //public float FadeOutTime = .5f;
    //public Color FadeOutColor = Color.black;
    private bool _isEnding;

    public AudioClipArray SuccessSound;

    public void Start()
    {
        if (IsOpen)
        {
            GameObject.Find("Door").renderer.material.color = Color.black;
            collider.enabled = true;
        }
    }

    public override void OnKeyAcquired()
    {
        SuccessSound.PlayRandomAtPoint(transform.position);
        collider.enabled = true;
        foreach (Transform child in transform)
        {
            if(child.name == "Handle")
            {
                DestroyObject(child.gameObject);
            }
            else if(child.name == "Door")
            {
                IsOpen = true;
                child.renderer.material.color = Color.black;
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (IsOpen && !other.isTrigger && other.gameObject.CompareTag("Player"))
        {
            _isEnding = true;
            StartCoroutine(FadeScene());
        }

    }

    public IEnumerator FadeScene()
    {
        //yield return new WaitForSeconds(FadeOutTime);
        if (_isEnding)
        {
            Application.LoadLevel(NextScene);
        }
        yield break;
    }


}
