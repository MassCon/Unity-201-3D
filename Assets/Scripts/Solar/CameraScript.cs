using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject sun;

    private Vector3 camSun;
    private float camSunEulerX;
    private float camSunEulerY;

    private float camEulerX;
    private float camEulerY;

    private Camera _camera;

    private void Start()
    {
        camEulerX = transform.eulerAngles.x;
        camEulerY = transform.eulerAngles.y;
        camSun = sun.transform.position - transform.position;
        camSunEulerX = 0f;
        camSunEulerY = 0f;
        _camera = GetComponent<Camera>();
    }
    void Update()
    {
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        camEulerY += mx;
        camEulerX -= my;

        if (Input.GetMouseButton(0))
        {
            camSunEulerX -= my;
            camSunEulerY += mx;
        }

    }
    private void LateUpdate()
    {

        transform.eulerAngles = new Vector3(camEulerX, camEulerY, 0f);
        if (Input.GetMouseButton(0))
        {
            transform.position = sun.transform.position - Quaternion.Euler(camSunEulerX, camSunEulerY, 0f) * camSun;
        }
        Vector2 scroll = Input.mouseScrollDelta;
        if (scroll != Vector2.zero)
        {
            float newValue = _camera.fieldOfView - scroll.y;
            if (newValue >= 5 && newValue <= 120) _camera.fieldOfView = newValue;
            else _camera.fieldOfView = _camera.fieldOfView < 5f ? 5f : 120f;
        }
    }
}
