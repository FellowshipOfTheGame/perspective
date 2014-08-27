using UnityEngine;

public class PerspectiveButton : MonoBehaviour {
    public string NextLevel;

    public void Awake()
    {
        GameObject.Find("Background music").GetComponent<AudioSource>().enabled = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            GameObject.Find("Background music").GetComponent<AudioSource>().enabled = true;
            Application.LoadLevel(NextLevel);
        }
    }
}
