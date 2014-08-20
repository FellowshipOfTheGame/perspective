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
        foreach (GameObject playerInstance in playerInstances)
        {
            if (playerInstance.GetComponent<PlayerDeath>().IsAlive)
                return;
        }

        GameObject player = (GameObject)Instantiate(PlayerDefault, transform.position, Quaternion.identity);
        player.tag = "Player";
        player.SetActive(true);
        Camera.main.GetComponent<CameraFollow>().Target = player.transform;
    }
}
