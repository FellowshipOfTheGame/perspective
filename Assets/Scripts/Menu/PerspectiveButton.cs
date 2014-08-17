using UnityEngine;
using System.Collections;

public class PerspectiveButton : MonoBehaviour {
    public string Link = "http://www.fog.icmc.usp.br/";
	
    public void OnMouseDown()
    {
        Application.OpenURL(Link);
    }
}
