using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    private Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D col)
    {
        col.rigidbody.gravityScale = 0;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        other.rigidbody.gravityScale = 90;
    }
}
