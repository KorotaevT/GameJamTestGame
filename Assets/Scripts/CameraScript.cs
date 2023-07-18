using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Camera camera;
    public float smoothSpeed = 0.125f;
    void Update()
    {
        Vector3 smoothedPosition = Vector3.Lerp(camera.transform.position, transform.position, smoothSpeed);
        camera.transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, -10);
    }
}
