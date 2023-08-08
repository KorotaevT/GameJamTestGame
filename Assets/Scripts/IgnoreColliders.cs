using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IgnoreColliders : MonoBehaviour
{
    void Start()
    {
        var colliders = GetComponentsInChildren<Collider2D>();
        
        for (int i = 0; i < colliders.Length; i++)
        {
            for (int t = i+1; t < colliders.Length; t++)
            {
                Physics2D.IgnoreCollision(colliders[i], colliders[t]);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Physics2D.IgnoreCollision(this.GameObject().GetComponent<Collider2D>(), this.GameObject().GetComponent<Collider2D>());
    }
}
