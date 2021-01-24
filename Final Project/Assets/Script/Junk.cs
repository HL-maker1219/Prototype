using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junk : MonoBehaviour
{
    public float attackDelay = 1f;
    private GameObject Player;
    private Animator animator;
    private bool _detectCollisions = false;
    public Health health;
    public Transform fireSpot;
    public Transform targetSpot;
    public bool Col = false;
    private int playerLayermask = 1 << 10;
    private Rigidbody2D enemyRb;
    public Transform Target;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        health = GameObject.Find("Player").GetComponent<Health>();
        enemyRb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("AnimState", 0);
        
        Col = Physics2D.Linecast(fireSpot.position, targetSpot.position, playerLayermask);
        Debug.DrawLine(fireSpot.position, targetSpot.position, Color.red);

        if (Col)
        {
            flip();
            
        }
        
    }

    IEnumerator OnAttack()
    {
        yield return new WaitForSeconds(attackDelay);
        Hit ();
        StartCoroutine(OnAttack());
    }

    void Hit()
    {
        animator.SetInteger("AnimState", 1);
        attackDelay = 2f;
        if (_detectCollisions == true)
        {
            health.DamagePlayer(1);
        }

    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _detectCollisions = true;
            StartCoroutine(OnAttack());
        }
    }

    void OnCollisionExit2D (Collision2D other)
    {
        if(other.gameObject.tag =="Player")
        {
            _detectCollisions = false;
        }
    }

    void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
