using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint2Script : MonoBehaviour
{
    [SerializeField] private Image indicator;

    private bool isActiveted;

    private float checkPointTimeout = 10f;
    void Start()
    {
        LabirintState.AddPropertyListener(nameof(LabirintState.isCheckPoint2ActivatorPassed), Activate);
        LabirintState.checkPoint2Amount = 1f;
        LabirintState.checkPoint2Passed = false;
    }

    void Update()
    {
        if (isActiveted)
        {
            LabirintState.checkPoint2Amount -= Time.deltaTime / checkPointTimeout;
            if (LabirintState.checkPoint2Amount > 0f)
            {
                indicator.fillAmount = LabirintState.checkPoint2Amount;
                indicator.color = new Color(
                    1f - indicator.fillAmount,
                    indicator.fillAmount,
                    0.3f
                );
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Checkpoint 2 Trigger enter " + other.name);
        LabirintState.checkPoint2Passed = true;
        Destroy(gameObject);
    }
    private void Activate()
    {
        isActiveted = true;
    }
    private void OnDestroy()
    {
        LabirintState.RemovePropertyListener(nameof(LabirintState.isCheckPoint2ActivatorPassed), Activate);
    }
}
