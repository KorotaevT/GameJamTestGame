using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsColliderScript : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }
}
