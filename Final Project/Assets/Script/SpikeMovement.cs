using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    public float speed = 5f;
    public Health health;
    public Rigidbody2D rb;
    public bool facingLeft;
    public Rigidbody2D enemyRb;
    public float distance;
    public Transform enemy;
    public Transform spike;

    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.Find("Player").GetComponent<Health>();
        rb = GetComponent<Rigidbody2D>();
        enemyRb = GameObject.FindGameObjectWithTag("FlyingEnemy").GetComponent<Rigidbody2D>();
        enemy = GameObject.FindGameObjectWithTag("FlyingEnemy").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distance = (spike.transform.position.x - enemy.transform.position.x);

        if (enemyRb.velocity.x > 0)
        {
            facingLeft = false;
        }
        else if (enemyRb.velocity.x < 0)
        {
            facingLeft = true;
        }
        Debug.Log(facingLeft);


        if (facingLeft == false)
        {
            rb.velocity = transform.right * speed;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (facingLeft == true)
        {
            rb.velocity = transform.right * -speed;
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (distance > 13)
        {
            Destroy(gameObject);
        }
        else if (distance < -13)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            health.DamagePlayer(1);
        }
    }

}