using UnityEngine;
using System.Collections;

public abstract class ButtonEventHandler : MonoBehaviour
{
    public abstract void OnButtonDown();
    public abstract void OnButtonUp();
}
