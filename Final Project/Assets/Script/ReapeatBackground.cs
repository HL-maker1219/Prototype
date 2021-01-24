using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReapeatBackground : MonoBehaviour
{
    private float _repeatwidth = 55;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        _repeatwidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - _repeatwidth)
        {
            transform.position = startPos;
        }
    }
}
