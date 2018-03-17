﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 10;
    public float jumpForce = 700f;
    public float groundRadius = 0.2f;
    public Transform groundCheck;
    public LayerMask defineGround;

    private Rigidbody2D rBody;
    private SpriteRenderer sRend;
    private Animator animator;

    private float moveH;
    private bool isGrounded = false;
    private bool isRight = true;

    // Use this for initialization
    void Start () {
        rBody = GetComponent<Rigidbody2D>();
        sRend = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isGrounded && Input.GetAxis("Jump") > 0 && rBody.velocity.y == 0)
        {
            isGrounded = false;
            animator.SetBool("Ground", isGrounded);
            rBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            
        }
    }

    // Do not need to use Time.deltaTime()
    void FixedUpdate()
    {
        // Checks whether character is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, defineGround);
        animator.SetBool("Ground", isGrounded);

        // Debug.Log("Grounded? " + isGrounded);

        // Pass vertical velocity to animator
        animator.SetFloat("vSpeed", rBody.velocity.y);
        
        // Read input
        moveH = Input.GetAxis("Horizontal");

        // Set speed variable in animator
        animator.SetFloat("Speed", Mathf.Abs(moveH));

        // Set character velocity
        rBody.velocity = new Vector2(moveH * maxSpeed, rBody.velocity.y);

        // Check direction and flip sprite
        if (rBody.velocity.x > 0 && !isRight)
        {
            Flip();
        }
        else if (rBody.velocity.x < 0 && isRight)
        {
            Flip();
        }

    }

    private void Flip()
    {
        isRight = !isRight;

        Vector3 temp = this.transform.localScale;
        temp.x *= -1;
        this.transform.localScale = temp;
    }
}
