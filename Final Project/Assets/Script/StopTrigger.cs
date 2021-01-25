using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTrigger : MonoBehaviour
{
    public float stopDistance;

    public Transform player;

    public float force = 5f;

    public Rigidbody2D Rb;

    public bool facingLeft;

    public float speed = 1f;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        Rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("AnimState", 0);

        GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 0) * -speed;

        if (Rb.velocity.x > 0)
        {
            facingLeft = false;
        }
        else if (Rb.velocity.x < 0)
        {
            facingLeft = true;
        }

        stopTrigger();
    }

    void stopTrigger()
    {
        if (Vector3.Distance(player.position, transform.position) <= stopDistance)
        {
            if (facingLeft == false)
            {
                Rb.AddForce(Vector2.right * -force, ForceMode2D.Force);
            }
            else if (facingLeft == true)
            {
                Rb.AddForce(Vector2.right * force, ForceMode2D.Force);
            }
        }
    }
}
