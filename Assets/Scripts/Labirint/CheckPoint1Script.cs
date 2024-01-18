using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Image indicator;

    private float checkPoint1Timeout = 10f;
    void Start()
    {
        LabirintState.checkPoint1Amount = 1f;
        LabirintState.checkPoint1Passed = false;
    }

    void Update()
    {
        LabirintState.checkPoint1Amount -= Time.deltaTime / checkPoint1Timeout;
        if (LabirintState.checkPoint1Amount > 0f)
        {
            indicator.fillAmount = LabirintState.checkPoint1Amount;
            indicator.color = new Color(
                1f - indicator.fillAmount,
                indicator.fillAmount,
                0.3f
            );
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Checkpoint 1 Trigger enter " + other.name);
        LabirintState.checkPoint1Passed = true;
        Destroy(gameObject);
    }
}
