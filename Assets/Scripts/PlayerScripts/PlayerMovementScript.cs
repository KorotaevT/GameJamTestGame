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
    public bool isGrounded = false;
    private Rigidbody2D rb;
    private float checkRadius = 0.05f;
    public GameObject LeftFistPos;
    public GameObject RightFistPos;
    private Vector2 startPoint;
    public float distance = 0.35f;
    private bool isFlipped = false;
    public bool isClimbing = false;
    public bool JumpFromLadder;

    private void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveHandsToHandle();
        MovementLogic();
        Jump();
        Debug.Log(isClimbing);
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
        startPoint = new Vector2(rb.position.x, rb.position.y + 0.1f);
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
        if (!isClimbing)
        {
            float moveHorizontal = ((Input.GetAxis("Horizontal") > 0)
                ? 1.0f
                : ((Input.GetAxis("Horizontal") < 0) ? -1.0f : 0.0f));
            foreach (Transform child in rb.transform.parent)
            {
                Rigidbody2D playerRigidbody = child.GetComponent<Rigidbody2D>();
                playerRigidbody.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);
                playerRigidbody.angularVelocity = 0;
            }
        }
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                foreach (Transform child in rb.transform.parent)
                {
                    Rigidbody2D playerRigidbody = child.GetComponent<Rigidbody2D>();
                    if (isClimbing)
                    {
                        JumpFromLadder = true;
                        isClimbing = false;
                    }
                    playerRigidbody.velocity = new Vector2(rb.velocity.x, jumpForce);
                }
            }
        }
    }
}