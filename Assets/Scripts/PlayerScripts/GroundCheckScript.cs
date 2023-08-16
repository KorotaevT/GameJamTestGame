using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckScipt : MonoBehaviour
{
    public GameObject torso;
    private void OnTriggerStay2D(Collider2D other)
    {
        torso.transform.GetComponent<PlayerScript>().isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        torso.transform.GetComponent<PlayerScript>().isGrounded = false;
    }
}
