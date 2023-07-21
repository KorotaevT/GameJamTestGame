using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
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
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);

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
}