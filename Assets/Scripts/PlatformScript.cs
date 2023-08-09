using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    private Collider2D platformCollider;
    private GameObject player;

    private void Start()
    {
        platformCollider = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");
        
        if (moveVertical < 0 || IsPlayerBelowPlatform())
        {
            platformCollider.enabled = false;
        }
        else
        {
            platformCollider.enabled = true;
        }
    }

    private bool IsPlayerBelowPlatform()
    {
        if (player != null)
        {
            Transform shinLeft = player.transform.parent.transform.Find("PlayerShinLeft");

            if (shinLeft != null && shinLeft.childCount > 0)
            {
                float playerShinY = shinLeft.GetChild(0).position.y;
                float platformMaxY = platformCollider.bounds.max.y;

                return playerShinY < platformMaxY;
            }
        }

        return false;
    }
}