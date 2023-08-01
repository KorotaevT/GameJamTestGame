using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private float maxSpeed = 150;
    private bool isGrounded;
    private Rigidbody2D rb;
    private Transform GroundCheck;
    private float checkRadius = 0.5f;
    public LayerMask ground ;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GroundCheck = transform.Find("Grounded");
    }

    void Update()
    {
        MovementLogic();
        CheckingGround();
        Jump();
    }


    private void MovementLogic()
    {
        float moveHorizontal = RoundToRange(Input.GetAxis("Horizontal"));
        rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ladder") && rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    float RoundToRange(float value)
    {
        if (value < 0)
        {
            return Mathf.Clamp(value, -1f, 0f);
        }
        else
        {
            return Mathf.Clamp(value, 0f, 1f);
        }
    }


    private void CheckingGround()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.GetComponent<CircleCollider2D>().bounds.center, checkRadius, ground);
    }


    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }

    private void MoveHandsToHandle()
    {
        
    }
}