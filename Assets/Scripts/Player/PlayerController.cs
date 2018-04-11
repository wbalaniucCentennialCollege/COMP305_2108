using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    public PlayerStats stats;

    private Rigidbody2D rBody;
    private Animator animator;

    private float moveH;
    private float distToGround;
    private bool isGrounded = false;
    private bool isRight = true;

    // Use this for initialization
    void Start () {
        rBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        distToGround = GetComponent<Collider2D>().bounds.extents.y;
        stats.groundCheck = transform.Find("GroundCheck").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(isGrounded && Input.GetAxis("Jump") > 0 && rBody.velocity.y == 0)
        {
            isGrounded = false;
            animator.SetBool("Ground", isGrounded);
            rBody.AddForce(new Vector2(0, stats.jumpForce), ForceMode2D.Impulse);
            
        }
    }

    // Do not need to use Time.deltaTime()
    void FixedUpdate()
    {
        // Checks whether character is grounded
        // isGrounded = Physics2D.OverlapCircle(stats.groundCheck.position, stats.groundRadius, stats.defineGround);
        isGrounded = CheckIsGrounded();
        animator.SetBool("Ground", isGrounded);

        // Debug.Log("Grounded? " + isGrounded);

        // Pass vertical velocity to animator
        animator.SetFloat("vSpeed", rBody.velocity.y);
        
        // Read input
        moveH = Input.GetAxis("Horizontal");

        // Set speed variable in animator
        animator.SetFloat("Speed", Mathf.Abs(moveH));

        // Set character velocity
        rBody.velocity = new Vector2(moveH * stats.walkSpeed, rBody.velocity.y);

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


    private bool CheckIsGrounded()
    {
        return Physics2D.Raycast(transform.position, -Vector3.up, distToGround + 0.1f, stats.defineGround);
    }

    public void Die()
    {
        Debug.Log("Player dead");
        // Play death animation
        animator.SetBool("isDead", true);
    }

    public void ResetDeathAnim()
    {
        animator.SetBool("isDead", false);
    }
}
