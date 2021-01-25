﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Worm : MonoBehaviour
{

    private Rigidbody2D playerRb;

    public float hitForce = 1f;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("AnimState", 0);
    }

    void OnCollisionEnter2D (Collision2D collison)
    {
        if (collison.gameObject.tag == "Player")
        {
            playerRb.AddForce(Vector2.up * hitForce, ForceMode2D.Impulse);

        }
    }
}
