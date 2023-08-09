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
        transform.GetComponent<Collider2D>().enabled = false;
        UpPoint = transform.Find("UpPoint");
        DownPoint = transform.Find("DownPoint");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");
        
        if (moveVertical < 0 || IsPlayerOnUpPoint())
        {
            Debug.Log(true);
        }
    }

    public bool IsPlayerOnUpPoint()
    {
        if (player != null)
        {
            Transform shinLeft = player.transform.parent.transform.Find("PlayerShinLeft").GetChild(0);
            Debug.Log("UpPoint = " + UpPoint.GetComponent<Collider2D>().bounds);
            Debug.Log("Noga = " +  shinLeft.GetComponent<Collider2D>().bounds);
            if (UpPoint.GetComponent<Collider2D>().bounds.Contains(shinLeft.position))
            {
                return true;
            }
                
        }

        return false;
    }
}
