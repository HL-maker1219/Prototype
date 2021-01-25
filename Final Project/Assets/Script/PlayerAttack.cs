using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public int damage;
    public bool AttacakOnTrigger;
    private Animator _animator;
    private AudioSource _playerAudio;
    public AudioClip attack;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AttacakOnTrigger == true)
        {
            if (timeBtwAttack <= 0)
            {
                if (Input.GetKey(KeyCode.X))
                {
                    _animator.SetInteger("Anim_Stat", 2);
                    Attack();
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        enemiesToDamage[i].GetComponent<EnemyHealth>().TakeDamage(damage);

                    }
                }
                timeBtwAttack = startTimeBtwAttack;

            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GetAttack")
        {
            AttacakOnTrigger = true;
        }
    }

    void Attack()
    {
        _playerAudio.PlayOneShot(attack, 1.0f);
    }
}
