using UnityEngine;

public abstract class ButtonResponse : MonoBehaviour
{
    public virtual void OnButtonDown(GameObject other) { }
    public virtual void OnButtonUp(GameObject other) { }
}