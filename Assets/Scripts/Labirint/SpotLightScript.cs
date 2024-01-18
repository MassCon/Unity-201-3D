using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightScript : MonoBehaviour
{
    [SerializeField] GameObject _camera;

    private Light spotLight;

    void Start()
    {
        spotLight = GetComponent<Light>();
    }

    void Update()
    {
        if (LabirintState.cameraFirtsPerson && !LabirintState.isDay)
        {
            transform.position = _camera.transform.position;
            transform.forward = _camera.transform.forward;
            Vector2 wheel = Input.mouseScrollDelta;
            if (wheel.y != 0)
            {
                float spotAngle = spotLight.spotAngle + wheel.y;
                if (spotAngle < 25f)
                {
                    spotAngle = 25f;
                }
                else if (spotAngle > 90f)
                {
                    spotAngle = 90f;
                }
                spotLight.spotAngle = spotAngle;
            }
        }
    }
}
