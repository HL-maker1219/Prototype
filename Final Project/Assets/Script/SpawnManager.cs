using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RespawnManager.instance.Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
