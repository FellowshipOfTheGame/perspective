using UnityEngine;
using System.Collections;

public class Door : KeyEventHandler {
    public AudioClipArray AudioClip;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    public override void OnKeyAcquired(int id)
    {
        AudioClip.PlayRandomAtPoint(transform.position);
        DestroyObject(gameObject);
    }
}
