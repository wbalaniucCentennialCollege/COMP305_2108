using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 10;
    public float jumpForce = 700f;
    public Transform groundCheck;
    public LayerMask defineGround;

    private Rigidbody2D rBody;
    private SpriteRenderer sRend;
    private Animator animator;

    private bool isRight = true;
    private bool isGrounded = false;
    private float groundRadius = 0.2f;

    // Use this for initialization
    void Start () {
        rBody = GetComponent<Rigidbody2D>();
        sRend = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isGrounded && Input.GetAxis("Jump") > 0)
        {
            animator.SetBool("Ground", false);
            rBody.AddForce(new Vector2(0, jumpForce));
        }
	}

    // Do not need to use Time.deltaTime()
    void FixedUpdate()
    {
        // Checks whether character is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, defineGround);
        animator.SetBool("Ground", isGrounded);

        // Pass vertical velocity to animator
        animator.SetFloat("vSpeed", rBody.velocity.y);

        // Read input
        float moveH = Input.GetAxis("Horizontal");

        // Set speed variable in animator
        animator.SetFloat("Speed", Mathf.Abs(moveH));

        // Set character velocity
        rBody.velocity = new Vector2(moveH * maxSpeed, rBody.velocity.y);

        // Check direction and flip sprite
        if (moveH > 0) {
            sRend.flipX = false;
        } else if(moveH < 0)
        {
            sRend.flipX = true;
        }
    }
}
