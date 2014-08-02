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
        GameObject player = (GameObject)Instantiate(PlayerPrefab, transform.position, Quaternion.identity);
        Camera.main.GetComponent<SmoothFollow>().target = player.transform;
    }
}
