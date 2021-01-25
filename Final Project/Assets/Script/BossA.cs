using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossA : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public float attackRange;
    public Transform attackPos;
    public LayerMask attackPlayer;
    public Health playerHealth;

    public Transform player;
    public float attackDistance;

    private Animator _bAnim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        _bAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (Vector3.Distance(player.position, transform.position) <= attackDistance)
            {
                _bAnim.SetInteger("Anim_stat", 1);
                Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, attackPlayer);
                for (int i = 0; i < playerToDamage.Length; i++)
                {
                    playerToDamage[i].GetComponent<Health>().DamagePlayer(1);
                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
            _bAnim.SetInteger("Anim_stat", 0);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
