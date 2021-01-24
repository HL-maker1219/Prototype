using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager instance;

    public Transform respawnPos;
    public GameObject playerPrefab;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    public void Respawn()
    {
        Instantiate(playerPrefab, respawnPos.position, Quaternion.identity);
    }
}
