using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float camAngleX;
    private float camAngleY;
    private float rodAngleX;
    private float rodAngleY;
    private Vector3 camRod;
    private void Start()
    {
        camAngleX = transform.eulerAngles.x;
        camAngleY = transform.eulerAngles.y;
        camRod = transform.position;
        rodAngleX = rodAngleY = 0f;
    }
    private void Update()
    {
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        if (camAngleX - my > 60)
        {
            camAngleX = 60;
        }
        else if (camAngleX - my < 35)
        {
            camAngleX = 35;
        }
        else
        {
            camAngleX -= my;

            rodAngleX -= my;
        }

        camAngleY += mx;

        rodAngleY += mx;
    }
    private void LateUpdate()
    {
        if (camAngleX > 60)
        {
            camAngleX = 60;
            rodAngleX = 0;
        }
        if (camAngleX < 35)
        {
            camAngleX = 35;
            rodAngleX = 0;
        }
        transform.eulerAngles = new Vector3(camAngleX, camAngleY, 0f);
        transform.position = Quaternion.Euler(rodAngleX, rodAngleY, 0f) * camRod;
    }
}
