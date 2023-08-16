using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHandleScript : MonoBehaviour
{

    public List<float> coords = new List<float>(2);

    private void Update()
    {
        coords[0]=transform.Find("Handle").position.x;
        coords[1]=transform.Find("Handle").position.y;
    }
}
