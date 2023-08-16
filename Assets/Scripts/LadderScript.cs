using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float climbingSpeed = 5f;
    private bool isOnLadder = false;
    public string ladderDirection = "left";
    
    private void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("yes");
        if (other.CompareTag("groundCheck"))
        {
            foreach (Transform child in other.transform.parent.parent)
            {
                Rigidbody2D playerRigidbody = child.GetComponent<Rigidbody2D>();
                if (playerRigidbody != null)
                {
                    playerRigidbody.gravityScale = 1f;
                    playerRigidbody.velocity = Vector2.zero;
                }
            }
            isOnLadder = false;
            transform.parent.GetComponent<Collider2D>().enabled = false;
            other.transform.parent.parent.Find("PlayerTorso(and Control)")
                .GetComponent<PlayerScript>().isClimbing = false;
            other.transform.parent.parent.Find("PlayerTorso(and Control)").GetComponent<PlayerScript>().JumpFromLadder = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetAxis("Vertical")!=0)
        {
            isOnLadder = true;
            
        }
        if (other.CompareTag("groundCheck") && isOnLadder)
        {
            bool playerJumping = other.transform.parent.parent.Find("PlayerTorso(and Control)")
                .GetComponent<PlayerScript>().JumpFromLadder;
            if (playerJumping)
            {
                OnTriggerExit2D(other);
                return;
            }
            other.transform.parent.parent.Find("PlayerTorso(and Control)").GetComponent<PlayerScript>().isClimbing =
                true;
            foreach (Transform child in other.transform.parent.parent)
            {
                Rigidbody2D playerRigidbody = child.GetComponent<Rigidbody2D>();
                if (playerRigidbody != null)
                {
                    playerRigidbody.velocity = Vector2.zero;
                    playerRigidbody.angularVelocity = 0f;
                    playerRigidbody.gravityScale = 0f;
                    playerRigidbody.drag = 0f;
                    playerRigidbody.angularDrag = 0f;
                    if (Input.GetAxis("Vertical") != 0)
                    {
                        float climbingAngleDeg;
                        if (ladderDirection == "left")
                        {
                            climbingAngleDeg = 135;
                        }
                        else
                        {
                            climbingAngleDeg = 45;
                        }
                        climbingAngleDeg = ((Input.GetAxis("Vertical") > 0) ? climbingAngleDeg : ((Input.GetAxis("Vertical") < 0) ? climbingAngleDeg + 180 : 0.0f));
                        float climbingAngleRad = Mathf.Deg2Rad * climbingAngleDeg;
                        Vector2 force = new Vector2(Mathf.Cos(climbingAngleRad), Mathf.Sin(climbingAngleRad));
                        Debug.Log(Mathf.Cos(climbingAngleRad));
                        Debug.Log(Mathf.Sin(climbingAngleRad));
                        playerRigidbody.AddForce(force * climbingSpeed);
                    }
                }
            }
            transform.parent.GetComponent<Collider2D>().enabled = true;
        }
    }
}
