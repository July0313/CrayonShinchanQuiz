using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Image timer;

    float timeToSelectAnswer = 10f;
    float timeToShowAnswer = 5f;
    float curTime = 0f;

    bool isSelecting;

    void Start()
    {
        timer = GetComponent<Image>();
        TimerInit();
    }

    void Update()
    {
        TimeSpend();
    }

    void TimerInit()
    {
        isSelecting = true;
        curTime = timeToSelectAnswer;
    }

    void TimeSpend()
    {
        if (curTime > 0)
        {
            curTime -= Time.deltaTime;
            if (isSelecting)
            {
                timer.color = Color.red;
                timer.fillAmount = (float)curTime / (float)timeToSelectAnswer;
            }
            else
            {
                timer.color = Color.cyan;
                timer.fillAmount = (float)curTime / (float)timeToShowAnswer;
            }
        }
        else
        {
            isSelecting = !isSelecting;
            curTime = isSelecting ? timeToSelectAnswer : timeToShowAnswer;
        }
    }
}
