using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Camera camera;
    public float smoothSpeed;
    public float panSpeed;

    private bool isPanning = false;
    private Vector3 lastMousePosition;
    private Vector3 panDirection;

    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            isPanning = true;
            lastMousePosition = Input.mousePosition;
            panDirection = Vector3.zero;
        }

        if (Input.GetMouseButtonUp(2))
        {
            isPanning = false;
        }

        if (isPanning)
        {
            Vector3 mousePosition = Input.mousePosition;
            panDirection = mousePosition - lastMousePosition;
            Vector3 pan = new Vector3(panDirection.x, panDirection.y).normalized * panSpeed * Time.deltaTime;
            camera.transform.Translate(pan, Space.Self);
        }
        else
        {
            Vector3 smoothedPosition = Vector3.Lerp(camera.transform.position, transform.position, smoothSpeed);
            camera.transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y + 100, -10);
        }
    }
}