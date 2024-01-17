using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenusScript : MonoBehaviour
{
    private GameObject surface;
    private GameObject atmosphere;
    private float dayPeriod = 20f / 360f;
    private float skyPeriod = 10f / 360f;
    private void Start()
    {
        surface = GameObject.Find("VenusSurface");
        atmosphere = GameObject.Find("VenusAtmosphere");
    }
    private void Update()
    {
        surface.transform.Rotate(Vector3.up, Time.deltaTime / dayPeriod, Space.Self);
        atmosphere.transform.Rotate(Vector3.up, Time.deltaTime / skyPeriod);
    }
}
