using UnityEngine;
using System.Collections;

public class QuitButton : MonoBehaviour
{
    public void OnMouseDown()
    {
        Application.Quit();
    }
}
