﻿using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 20f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 2000f;
    
    
    public Vector2 panLimit;
    public float minY = 20f;
    public float maxY = 120f;

    void Update()
    {
        Vector3 pos = transform.position;
        
        if (Input.GetKey(KeyCode.UpArrow) || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
            pos.x += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
            pos.x -= panSpeed * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.RightArrow) || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
            pos.x += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.mousePosition.x <= panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
            pos.x -= panSpeed * Time.deltaTime;
        } 

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);

        transform.position = pos;

    }
}
