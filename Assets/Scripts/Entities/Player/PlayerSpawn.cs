using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject PlayerPrefab;

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
            {
                return;
            }
        }

        GameObject player = (GameObject)Instantiate(PlayerPrefab, transform.position, Quaternion.identity);
        Camera.main.GetComponent<SmoothFollow>().target = player.transform;
    }
}
