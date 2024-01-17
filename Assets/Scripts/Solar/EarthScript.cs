using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthScript : MonoBehaviour
{
    private GameObject surface;
    private GameObject atmosphere;

    private GameObject sun;
    private float dayPeriod = 24f / 360f;
    private float skyPeriod = 12f / 360f;
    private float yearPeriod = 36.5f / 360f;
    private void Start()
    {
        surface = GameObject.Find("EarthSurface");
        atmosphere = GameObject.Find("EarthAtmosphere");
        sun = GameObject.Find("Sun");
    }
    private void Update()
    {
        surface.transform.Rotate(Vector3.up, Time.deltaTime / dayPeriod, Space.Self);
        atmosphere.transform.Rotate(Vector3.up, Time.deltaTime / skyPeriod);

        this.transform.RotateAround(sun.transform.position, Vector3.up, Time.deltaTime/ yearPeriod);
    }
}
