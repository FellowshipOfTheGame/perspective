using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public string Level1 = "Level 1";

    public void Awake()
    {
        GameObject.Find("Background music").GetComponent<AudioSource>().enabled = false;
    }

    public void OnMouseDown()
    {
        GameObject.Find("Background music").GetComponent<AudioSource>().enabled = true;
        Application.LoadLevel(Level1);
    }
}
