using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour {

    private Rigidbody2D rBody;
    private Animator animator;
    private Vector3 lastPosition;
    private bool isRight = true;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
    }

    void Update()
    {
        Vector2 velocity = lastPosition - this.transform.position;

        if (velocity.x > 0 && isRight)
        {
            Flip();
        } else if (velocity.x < 0 && !isRight)
        {
            Flip();
        }
        
        animator.SetFloat("Speed", Mathf.Abs(velocity.x));
    
        lastPosition = this.transform.position;
    }

    private void Flip()
    {
        isRight = !isRight;

        Vector3 temp = this.transform.localScale;
        temp.x *= -1;
        this.transform.localScale = temp;
    }
}
