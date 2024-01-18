using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    private bool _isDay;
    private bool isDay
    {
        get => _isDay;
        set
        {
            LabirintState.isDay = _isDay = value;
            if (_isDay) SetDayLighting();
            else SetNightLighting();
        }
    }
    private Light lightComponent;

    void Start()
    {
        lightComponent = GetComponent<Light>();
        isDay = true;
    }
    void Update()
    {
        if (LabirintState.isPaused) return;

        if (Input.GetKeyUp(KeyCode.N))
        {
            isDay = !isDay;
        }

        if (Input.GetKey(KeyCode.Equals) && lightComponent.intensity < 1f)
        {
            float intensity = lightComponent.intensity + 0.01f;
            if (intensity >= 1f) lightComponent.intensity = 1f;
            else lightComponent.intensity = intensity;
        }
        if (Input.GetKey(KeyCode.Minus) && lightComponent.intensity > 0.01f)
        {
            float intensity = lightComponent.intensity - 0.01f;
            if (intensity <= 0.01f) lightComponent.intensity = 0.01f;
            else lightComponent.intensity = intensity;
        }
    }

    private void SetDayLighting()
    {
        lightComponent.intensity = 1f;
        RenderSettings.skybox.SetFloat("_Exposure", 1f);
    }
    private void SetNightLighting()
    {
        lightComponent.intensity = 0.05f;
        RenderSettings.skybox.SetFloat("_Exposure", 0.05f);

    }
}
