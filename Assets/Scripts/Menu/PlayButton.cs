using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour
{
    public string Level1 = "Level 1";
    public void OnMouseDown()
    {
        Application.LoadLevel(Level1);
    }
}
