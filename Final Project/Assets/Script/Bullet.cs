using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float attackDelay = 1f;
    public float attackDistance = 5f;
    public Transform player;
    private int conditional = 1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= attackDistance)
        {
            if (conditional == 1)
            {
                StartCoroutine(OnAttack());
            }
        }
    }

    IEnumerator OnAttack()
    {
        conditional = conditional + 1;
        yield return new WaitForSeconds(attackDelay);
        shot();
        StartCoroutine(OnAttack());
    }

    void shot()
    {
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        attackDelay = 2f;
    }
}
