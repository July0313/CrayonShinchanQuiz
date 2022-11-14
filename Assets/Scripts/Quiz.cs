using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Question")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions;
    QuestionSO currentQuestion;
    string correctString;

    [Header("Answer Button")]
    [SerializeField] Button[] answerBtns;
    TextMeshProUGUI[] answerBtnTexts = new TextMeshProUGUI[4];

    void Awake()
    {
        for (int i = 0; i < answerBtns.Length; i++)
        {
            answerBtns[i] = answerBtns[i].GetComponent<Button>();
            answerBtnTexts[i] = answerBtns[i].GetComponentInChildren<TextMeshProUGUI>();
        }

        DisplayQuestion();
    }

    void GetRandomQuestion()
    {
        Debug.Log("1. GetRandomQuestion()");
        int idx = Random.Range(0, questions.Count);
        currentQuestion = questions[idx];
        questions.RemoveAt(idx);
    }

    void SetQuestionText(string text)
    {
        questionText.text = text;
    }

    void SetButtonText()
    {
        for (int i = 0; i < answerBtns.Length; i++)
        {
            answerBtnTexts[i].text = currentQuestion.GetAnswer(i);
        }
    }

    void SetButtonState(bool state)
    {
        for (int i = 0; i < answerBtns.Length; i++)
        {
            answerBtns[i].interactable = state;
        }
    }

    void SetButtonColor(int idx, Color color)
    {
        Debug.Log("버튼 컬러 바꾸기" + color);
        answerBtns[idx].GetComponent<Image>().color = color;
    }

    void SetButtonDefault()
    {
        for (int i = 0; i < answerBtns.Length; i++)
        {
            SetButtonColor(i, Color.white);
        }
        SetButtonText();
        SetButtonState(true);
    }

    // 퀴즈 출력
    void DisplayQuestion()
    {
        GetRandomQuestion();
        SetQuestionText(currentQuestion.Question);
        SetButtonDefault();
    }

    void AfterButtonSelected(int idx)
    {
        SetButtonState(false);
        SetButtonColor(currentQuestion.CorrectAnswerIdx, Color.green);

        if (currentQuestion.CorrectAnswerIdx != idx)
        {
            correctString = currentQuestion.GetAnswer(currentQuestion.CorrectAnswerIdx);
            SetQuestionText("The Answer is \n" + correctString);
            SetButtonColor(idx, Color.red);
        }
        else
        {
            SetQuestionText("Correct!");
        }
    }

    public void OnButtonSelected(int idx)
    {
        if (questions.Count == 0)
        {
            Debug.Log("questsion 끝남");
            GameManager.instance.IsGameOver = true;
            return;
        }

        AfterButtonSelected(idx);

        if (GameManager.instance.IsSelecting)
        {
            
        }

        // 다음 문제 출력
        DisplayQuestion();
    }
}


// 버튼 역할
// 0 시작할 때 버튼 텍스트 부르기
// 0 시작할 때 interactable 켜기
// 0 시작할 때 Color 전부 초기화
// 0 버튼을 선택하면 모든 버튼의 interactable 끄기
// 선택한 버튼의 컬러 바꾸
// (맞으면 맞은 버튼만 초록색으로, 틀리면 원래 정답은 초록색, 틀린 답은 빨간색)

/*
제한시간을 만듦(타이머 스크립트)
- float curTime
- float answerSelectTime
- float answerShowTime

게임 매니저
- bool형 isSelecting	// 답안 선택중인가?
- bool형 isShowing	// 답안 표시중인가?

타이머 스크립트에서 각각 제한시간을 줄이는 함수를 만듦(그냥 함수? 혹은 코루틴?)
-> 잘 모르겠으니 update문에서 curTime -= Time.deltaTime
// 아니면 코루틴을 돌려두고 (시간과 별개로 시간을 담은 WaitForSeconds 변수를 저장해서
코루틴을 담은 변수를 추가적으로 선언 및 저장해서 코루틴이 비거나 리턴이 되면 상태가 바뀌는 식으로)

제한시간이 끝나면 게임매니저의 bool형 답변을 조절

Quiz 스크립트에서는 게임매니저의 bool형 답변으로 상태 확인
-> 함수 호출 시 확인
*/