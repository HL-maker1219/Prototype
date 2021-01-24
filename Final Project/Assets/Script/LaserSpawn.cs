using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserSpawn : MonoBehaviour
{

    public GameObject laserPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Laser()
    {
        Instantiate(laserPrefab, transform.position, laserPrefab.transform.rotation);
    }
}
