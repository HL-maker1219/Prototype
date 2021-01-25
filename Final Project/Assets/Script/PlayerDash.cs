using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDash : MonoBehaviour{

    private Rigidbody2D rb;
    public float speed;
    public float jumpForce; 
    private float moveInput;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    private  int extraJumps;
    public int extraJumpValue;

    private Vector2 Dash;
    public float Xincrement;

    public float  cooldownTime = 2;
    public bool active;
    public float timer;

    public bool PU;
    public bool djPU;

    private AudioSource _playerAudio;
    public AudioClip jumpSound;
    public AudioClip dashSound;



    void Start(){
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
        _playerAudio = GetComponent<AudioSource>();
    }

    void FixedUpdate(){
       
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update(){

        if (active)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            timer = 0;
            active = false;
        }

        if (PU == true)
        {
            if (timer == 0)
            {

                if (Input.GetKeyDown(KeyCode.D))
                {
                    Dash = new Vector2(transform.position.x + Xincrement, transform.position.y);
                    transform.position = Dash;
                    timer = cooldownTime;
                    active = true;
                    DashSound();
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    Dash = new Vector2(transform.position.x - Xincrement, transform.position.y);
                    transform.position = Dash;
                    timer = cooldownTime;
                    active = true;
                    DashSound();
                }
            }
        }

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded == true){
            extraJumps = extraJumpValue ;
        }

        if (djPU)
        {
            if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                extraJumps--;
                JumpSound();
            }
            else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
            {
                rb.velocity = Vector2.up * jumpForce;
                JumpSound();
            }
        }
        
        if(moveInput > 0){
            transform.eulerAngles = new Vector3(0, 0, 0);
        }else if(moveInput < 0){
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space)){
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            JumpSound();
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true) {

            if (jumpTimeCounter > 0) {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
                if (jumpTimeCounter == 0.55)
                    JumpSound();
            } else {
                isJumping = false;
            }
            
            
        }

        if (Input.GetKeyUp(KeyCode.Space)){
            isJumping = false; 
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DashPowerUp")
        {
            PU = true;
        }
        else if (collision.gameObject.tag == "djPowerUp")
        {
            djPU = true;
        }
    }

    void JumpSound()
    {
        _playerAudio.PlayOneShot(jumpSound, 1.0f);
    }

    void DashSound()
    {
        _playerAudio.PlayOneShot(dashSound, 1.0f);
    }

}

    