using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject[] ReactiveChunks;

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

        GameObject player = (GameObject)Instantiate(PlayerPrefab, transform.position, Quaternion.identity);
        Camera.main.GetComponent<CameraFollow>().Target = player.transform;

        foreach (GameObject chunk in ReactiveChunks)
            foreach (Transform child in chunk.transform)
            {
                child.gameObject.SetActive(true);
                child.gameObject.GetComponent<ExplosionEventHandler>().Enabled = true;
            }
    }
}
