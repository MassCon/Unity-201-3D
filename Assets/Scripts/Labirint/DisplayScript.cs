using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI clock;
    private float gameTime;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    private int score;

    //[SerializeField]
    private TextMeshProUGUI checkPointsPassed;

    [SerializeField]
    private Image image1; // for checkpoint1 indicator
    [SerializeField]
    private Image image2; // for checkpoint2 indicator

    void Start()
    {
        //LabirintState.AddPropertyListener(nameof(LabirintState.checkPoint1Amount), OnCheckPoint1AmountChanged);
        //LabirintState.AddPropertyListener(nameof(LabirintState.checkPoint2Amount), OnCheckPoint2AmountChanged);
        //LabirintState.AddPropertyListener(nameof(LabirintState.checkPoint1Passed), OnCheckPointPassed);
        //LabirintState.AddPropertyListener(nameof(LabirintState.checkPoint2Passed), OnCheckPointPassed);
        gameTime = 0f;
        score = 100;
        StartCoroutine("ScoreReduce");
    }

    void Update()
    {
        gameTime += Time.deltaTime;
    }

    private void LateUpdate()
    {
        int time = (int)gameTime;
        int hour = time / 3600;
        int minute = (time % 3600) / 60;
        int second = time % 60;
        int decisecond = (int)((gameTime - time) * 10);
        clock.text = $"{hour:00}:{minute:00}:{second:00}.{decisecond:0}";
    }

    private IEnumerator ScoreReduce()
    {
        while (score > 0)
        {
            yield return new WaitForSeconds(5);
            score -= 1;
            scoreText.text = score.ToString();
        }
    }

    private void OnLabirinthStateChanged(string propertyName)
    {
        if (propertyName == nameof(LabirintState.checkPoint1Amount))
        {
            image1.fillAmount = LabirintState.checkPoint1Amount;
        }
    }
    private void OnCheckPoint1AmountChanged()
    {
        image1.fillAmount = LabirintState.checkPoint1Amount;
    }
    private void OnCheckPoint2AmountChanged()
    {
        //image2.fillAmount = LabirintState.checkPoint2Amount;
    }
    private void OnCheckPointPassed()
    {
        //if (LabirintState.checkPoint2Passed)
        //{
        //    checkPointsPassed.text = "2";
        //}
        //else
        if (LabirintState.checkPoint1Passed)
        {
            checkPointsPassed.text = "1";
        }
    }
    private void OnDestroy()
    {
        //LabirintState.RemoveNotifyListener(OnLabirinthStateChanged);
        //LabirintState.RemovePropertyListener(nameof(LabirintState.checkPoint1Amount), OnCheckPoint1AmountChanged);
        //LabirintState.RemovePropertyListener(nameof(LabirintState.checkPoint2Amount), OnCheckPoint2AmountChanged);

        //LabirintState.RemovePropertyListener(nameof(LabirintState.checkPoint1Passed), OnCheckPointPassed);
        //LabirintState.RemovePropertyListener(nameof(LabirintState.checkPoint2Passed), OnCheckPointPassed);
    }
}
