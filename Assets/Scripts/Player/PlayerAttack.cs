using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public GameObject attackCheck;

    private Animator animator;

	// Use this for initialization
	void Start () {
        attackCheck.SetActive(false);
	}

    void Update()
    {
        if(Input.GetAxis("Fire1") > 0)
        {
            animator.SetTrigger("Attack");
        }
    }

    void CheckAttack()
    {
        attackCheck.SetActive(true);
    }

    void DisableAttack()
    {
        attackCheck.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            // Do damage
            DisableAttack();
        }
    }
}
