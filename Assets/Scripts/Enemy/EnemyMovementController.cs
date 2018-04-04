using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour {
    
    private Animator animator;
    private Vector3 lastPosition;
    private bool isRight = true;

    private Vector2 forwardVector;

    private Rigidbody2D rBody;

    void Start()
    {
        animator = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rBody.velocity.x > 0 && !isRight)
        {
            Flip();
        } else if (rBody.velocity.x < 0 && isRight)
        {
            Flip();
        }
        
        animator.SetFloat("Speed", Mathf.Abs(rBody.velocity.x));
    }

    public void Move(Vector3 target)
    {
        // Rotate player towards the target
        forwardVector = target - transform.position;
        forwardVector.Normalize();

        // Move towards the target
        rBody.velocity = forwardVector * 2.0f;
    }

    private void Flip()
    {
        isRight = !isRight;

        Vector3 temp = this.transform.localScale;
        temp.x *= -1;
        this.transform.localScale = temp;
    }
}
