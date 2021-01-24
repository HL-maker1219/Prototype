using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAttack : MonoBehaviour
{
    public float force = 100f;
    private int attackMode;
    public float attackDistance = 4f;
    public int onlyUpdateOnce = 1;
    public float attackDelay = 3f;
    public Transform player;
    public float speed = 1f;
    public Health health;
    public float crashForce = 8f;
    private Rigidbody2D playerRb;
    public GameObject[] enemyPrefabs;
    public GameObject laserPrefab;
    public Transform laserPos1;
    public Transform laserPos2;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        health = GameObject.Find("Player").GetComponent<Health>();
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {

        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.position, step);

        if (Vector3.Distance(player.position, transform.position) <= attackDistance)
        {
            if (onlyUpdateOnce == 1)
            {
                StartCoroutine(OnAttack());
            }
        }
        Debug.Log(attackMode);
    }

    IEnumerator OnAttack()
    {
        onlyUpdateOnce = 2;
        yield return new WaitForSeconds(attackDelay);
        if (attackMode == 1)
        {
            Crash();
        }
        else if (attackMode == 2)
        {
            speed = 1;
            Summon();
        }
        else if (attackMode == 3)
        {
            speed = 1;
            Laser();
        }
        else if (attackMode == 4)
        {
            speed = 1;
        }
        
        attackMode = Random.Range(1, 4);
        StartCoroutine(OnAttack());

    }

    void Crash()
    {
        speed = 5f;
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (speed == 4f)
            {
                health.DamagePlayer(1);
                playerRb.AddForce(Vector2.up * crashForce, ForceMode2D.Impulse);
            }
        }
    }

    void Summon()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[enemyIndex], transform.position = new Vector2(transform.position.x - 2,transform.position.y), enemyPrefabs[enemyIndex].transform.rotation);
        Instantiate(enemyPrefabs[enemyIndex], transform.position = new Vector2(transform.position.x + 2, transform.position.y), enemyPrefabs[enemyIndex].transform.rotation);
    }

    void Laser()
    {
        Instantiate(laserPrefab, laserPos1.position, laserPrefab.transform.rotation);
        Instantiate(laserPrefab, laserPos2.position, laserPrefab.transform.rotation);
    }
}
