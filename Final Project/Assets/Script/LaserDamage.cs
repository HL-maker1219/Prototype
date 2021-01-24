using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDamage : MonoBehaviour
{
    
    private Health health;
    public Rigidbody2D playerRb;
    public float force;
    public int laserDur = 1;
    private int CountingDelay = 1;

    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.Find("Player").GetComponent<Health>();
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        StartCoroutine(OnCountingDown());
    }

    // Update is called once per frame
    void Update()
    {
        if (laserDur == 5)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator OnCountingDown()
    {
        yield return new WaitForSeconds(CountingDelay);
        laserDur = laserDur + 1;
        StartCoroutine(OnCountingDown());
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            health.DamagePlayer(1);
            Destroy(gameObject);
        }
    }
}
