using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public PlayerStats stats;

    private Animator animator;
    private Collider2D col;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        stats.attackCheck = transform.Find("AttackCheck").transform; 
	}

    void Update()
    {
        if (Input.GetAxis("Fire1") > 0 && !animator.GetBool("Attack"))
        {
            animator.SetTrigger("Attack");
            
            audioSource.clip = stats.swordSwing[0];
            audioSource.Play();

            col = Physics2D.OverlapCircle(stats.attackCheck.position, 0.2f, stats.defineAttack);
            

            if(col != null && col.tag == "Enemy")
            {
                // Debug.Log("Enemy Hit");
                col.GetComponent<EnemyHealth>().Damage(stats.attackDamage);
            }
        }
    }

    public void ResetAtttack()
    {
        animator.ResetTrigger("Attack");
    }
}
