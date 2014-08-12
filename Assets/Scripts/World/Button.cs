using UnityEngine;
using System;

public class Button : MonoBehaviour {
    private Vector3 OriginalPosition;
    private bool Pressed;
    private bool IsPressing;
    private bool IsReleasing;
	private float LastAction;
    public event Action OnButtonDown;
    public event Action OnButtonUp;
	// Use this for initialization
	void Start () {
        OriginalPosition = transform.position;
		LastAction = Time.realtimeSinceStartup;
        foreach (ButtonEventHandler eventHandler in GetComponents<ButtonEventHandler>())
        {
            OnButtonDown += eventHandler.OnButtonDown;
            OnButtonUp += eventHandler.OnButtonUp;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!Pressed && IsPressing)
        {
            transform.position = new Vector3(OriginalPosition.x, 0.0f, OriginalPosition.z);
            IsPressing = false;
            Pressed = true;
            if(OnButtonDown != null)OnButtonDown();
        }
        else if (Pressed && IsReleasing)
        {
            transform.position = OriginalPosition;
            IsReleasing = false;
            Pressed = false;
            if (OnButtonUp != null) OnButtonUp();
        }
	}

    public void OnCollisionEnter(Collision collision)
    {
		if (Time.realtimeSinceStartup - LastAction < 0.2f)
			return;
        foreach(ContactPoint contact in collision.contacts)
            if(contact.otherCollider.CompareTag("Player") && !Pressed)
			{
				LastAction = Time.realtimeSinceStartup;
                IsPressing = true;
                IsReleasing = false;
            }
    }

    public void OnCollisionExit(Collision collision)
	{
		if (Time.realtimeSinceStartup - LastAction < 0.02f)
			return;
        foreach (ContactPoint contact in collision.contacts)
            if (contact.otherCollider.CompareTag("Player") && Pressed)
			{
				LastAction = Time.realtimeSinceStartup;
                IsPressing = false;
                IsReleasing = true;
            }
    }
}
