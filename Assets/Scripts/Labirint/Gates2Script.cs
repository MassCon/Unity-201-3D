using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates2Script : MonoBehaviour
{
    private float period = 100f / 360f;
    void Start()
    {
        LabirintState.AddPropertyListener(nameof(LabirintState.checkPoint2Passed), OnCheckPoint2Passed);
    }
    void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime / period);
    }
    private void OnCheckPoint2Passed()
    {
        if (LabirintState.checkPoint2Passed)
            period /= 10f;
    }
    private void OnDestroy()
    {
        LabirintState.RemovePropertyListener(nameof(LabirintState.checkPoint2Passed), OnCheckPoint2Passed);
    }
}
