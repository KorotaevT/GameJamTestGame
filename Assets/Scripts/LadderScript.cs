using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform UpPoint;
    private Transform DownPoint;
    private GameObject player;

    private void Start()
    {
        UpPoint = transform.Find("UpPoint");
        DownPoint = transform.Find("DownPoint");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");
    }
    
    public float climbingSpeed = 1.0f;

    private bool isOnLadder = false;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Transform child in other.transform.parent.transform)
            {
                Rigidbody2D playerRigidbody = child.GetComponent<Rigidbody2D>();
                if (playerRigidbody != null)
                {
                    playerRigidbody.gravityScale = 1f;
                }
            }
            isOnLadder = false;
            transform.parent.GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetAxis("Vertical")!=0)
        {
            isOnLadder = true;
            
        }
        if (other.CompareTag("Player") && isOnLadder)
        {
            foreach (Transform child in other.transform.parent.transform)
            {
                Rigidbody2D playerRigidbody = child.GetComponent<Rigidbody2D>();
                if (playerRigidbody != null)
                {
                    playerRigidbody.velocity = Vector2.zero;
                    playerRigidbody.angularVelocity = 0f;
                    playerRigidbody.gravityScale = 0f;
                    playerRigidbody.drag = 0f;
                    playerRigidbody.angularDrag = 0f;
                }
            }
            transform.parent.GetComponent<Collider2D>().enabled = true;
        }
    }
}
