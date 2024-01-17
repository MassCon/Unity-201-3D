using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonScript : MonoBehaviour
{
    //[SerializeField]
    private GameObject earth;
    [SerializeField]
    private GameObject sun;

    [SerializeField]
    private float dayPeriod = 12f / 360f;
    [SerializeField]
    private float monthPeriod = 12f / 360f;
    [SerializeField]
    private float yearPeriod = 36.5f / 360f;

    private void Start()
    {
        earth = GameObject.Find("Earth");
    }

    void Update()
    {
        this.transform.Rotate(Vector3.up, Time.deltaTime / dayPeriod);

        this.transform.RotateAround(earth.transform.position,
            Vector3.up, Time.deltaTime / monthPeriod);

        this.transform.RotateAround(sun.transform.position,
            Vector3.up, Time.deltaTime / yearPeriod);
    }
}
