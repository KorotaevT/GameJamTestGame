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
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        MovementLogic();
    }

    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);
        Debug.Log(isGrounded);
        Debug.Log(moveVertical);
        if (moveVertical>0 && isGrounded)
        {
            Jump();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("LevelObjects"))
        {
            isGrounded = true;
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isGrounded = false;
    }


    private void Jump()
    {
        Debug.Log("jump");
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}