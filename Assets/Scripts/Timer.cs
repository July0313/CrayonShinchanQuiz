using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{ 
    Image timerFillImg;

    [Header("문제풀이 시간")]
    [SerializeField] float selectAnswerTime = 10f;
    [SerializeField] float showAnswerTime = 5f;

    float curTime, divisorTime;
    bool isSelecting = true;

    void Start()
    {
        timerFillImg = GetComponentInChildren<Image>();

        SetTimer(true);
    }

    void Update()
    {
        curTime -= Time.deltaTime;
        timerFillImg.fillAmount = curTime / divisorTime;

        if (curTime <= 0)
        {
            SetTimer(!isSelecting);
        }
    }

    void SetTimer(bool _isSelecting)
    {
        isSelecting = _isSelecting;
        GameManager.instance.SetSelectingState(isSelecting);

        timerFillImg.color = isSelecting ? Color.green : Color.gray;
        divisorTime = isSelecting ? selectAnswerTime : showAnswerTime;
        curTime = divisorTime;
    }
}
