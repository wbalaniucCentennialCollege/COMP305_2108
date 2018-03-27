using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public float weaponDamage = 5.0f;

    public Transform attackCheck;
    public float attackCheckRadius = 0.2f;
    public LayerMask defineAttack;
    public AudioClip swordSwing;

    private Animator animator;
    private Collider2D col;
    private bool isAttacking = false;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
	}

    void Update()
    {
        if(Input.GetAxis("Fire1") > 0 && !isAttacking)
        {
            isAttacking = true;
            animator.SetTrigger("Attack");
            
            audioSource.clip = swordSwing;
            audioSource.Play();

            col = Physics2D.OverlapCircle(attackCheck.position, 0.2f, defineAttack);

            if(col != null && col.tag == "Enemy")
            {
                // Debug.Log("Enemy Hit");
                col.GetComponent<EnemyHealth>().Damage(weaponDamage);
            }
        }
    }

    public void ResetAtttack()
    {
        isAttacking = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
    }
}
