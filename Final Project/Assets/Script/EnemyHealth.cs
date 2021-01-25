using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    private Animator animator;
    private AudioSource _enemyAudio;
    public AudioClip attacked;
    public AudioClip dead;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        _enemyAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("damage TAKEN !");
        animator.SetTrigger("Attacked");
        AttackedSound();
    }
    void AttackedSound()
    {
        _enemyAudio.PlayOneShot(attacked, 1.0f);
    }

    void DeadSound()
    {
        _enemyAudio.PlayOneShot(dead, 1.0f);
    }
}
