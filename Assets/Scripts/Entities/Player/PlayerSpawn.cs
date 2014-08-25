using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject PlayerDefault;

    public void Awake()
    {
        Spawn();
    }

    public void Spawn()
    {
        GameObject[] playerInstances = GameObject.FindGameObjectsWithTag("Player");
        int layerID = 0;
        foreach (GameObject playerInstance in playerInstances)
        {
            if (playerInstance.GetComponent<PlayerDeath>().IsAlive)
            {
                return;
            }
            else
            {
                layerID = playerInstance.GetComponent<LayerControl>().LayerID;
            }
        }

        GameObject player = (GameObject)Instantiate(PlayerDefault, transform.position, Quaternion.identity);
        player.tag = "Player";
        player.SetActive(true);
        player.GetComponent<LayerControl>().LayerID = layerID;
        Camera.main.GetComponent<SmoothFollow>().Target = player.transform;
    }
}
