using UnityEngine;
using System.Collections;

public class Door : KeyEventHandler {
    public AudioClipArray AudioClip;

    public override void OnKeyAcquired(int id)
    {
        AudioClip.PlayRandomAtPoint(transform.position);
        DestroyObject(gameObject);
    }
}
