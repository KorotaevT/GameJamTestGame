using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private float maxSpeed = 1.5f;
    private bool isGrounded;
    private Rigidbody2D rb;
    private Transform GroundCheck;
    private float checkRadius = 0.05f;
    public LayerMask ground ;
    public GameObject LeftFistPos;
    public GameObject RightFistPos;
    private Vector2 startPoint;
    private float distance = 0.35f;
    private bool isFlipped = false;

    private void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        GroundCheck = transform.Find("Grounded");
    }

    void Update()
    {
        MovementLogic();
        CheckingGround();
        Jump();
        MoveHandsToHandle();
    }
    
    private void FlipSprite(SpriteRenderer spriteRenderer)
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    private void FlipSpritesInChildren(Transform parentTransform)
    {
        foreach (Transform child in parentTransform)
        {
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                FlipSprite(spriteRenderer);
            }
            
            FlipSpritesInChildren(child);
        }
    }

    public void MoveHandsToHandle()
    {
        startPoint = rb.position;
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = cursorPosition - (Vector3)startPoint;
        Vector2 directionNormalized = direction.normalized;
        Vector2 middlePoint = startPoint + directionNormalized * distance;
        LeftFistPos.transform.position = new Vector3(middlePoint.x, middlePoint.y, rb.transform.position.z);
        RightFistPos.transform.position = new Vector3(middlePoint.x, middlePoint.y, rb.transform.position.z);

        if ((cursorPosition.x < startPoint.x && !isFlipped) || (cursorPosition.x > startPoint.x && isFlipped))
        {
            FlipSpritesInChildren(transform.parent);
            isFlipped = !isFlipped;
        }
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
       // isGrounded = Physics2D.OverlapCircle(GroundCheck.GetComponent<CircleCollider2D>().bounds.center, checkRadius, ground);
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