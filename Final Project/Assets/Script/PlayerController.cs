using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //switch to walk animation
        if (Input.GetKey("left"))
        {
           spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = true;
            _animator.SetInteger("Anim_Stat", 1); 
        }
        else if (Input.GetKey("right"))
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = false;
            _animator.SetInteger("Anim_Stat", 1);
        }
        else
        {
            _animator.SetInteger("Anim_Stat", 0);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            _animator.SetInteger("Anim_Stat", 2);
        }
    }
}
