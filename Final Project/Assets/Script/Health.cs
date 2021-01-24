using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int curHealth = 0;

    public int maxHealth = 100;

    public HealthBar1 healthBar;

    private Rigidbody2D playerRb;

    public float hitForce = 1;

    public bool Alive;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

        curHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (curHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("I am gone,byebye!");
            RespawnManager.instance.Respawn();
        }
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Worm")
        {
            DamagePlayer(1);
        }
    }

    public void DamagePlayer(int damage)
    {
        curHealth -= damage;

        healthBar.SetHealth(curHealth);
    }

}
