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
    [SerializeField] QuestionSO currentQuestion;

    [Header("Answer Button")]
    [SerializeField] Button[] answerBtns;
    TextMeshProUGUI[] answerBtnTexts = new TextMeshProUGUI[4];

    void Start()
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
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];
        questions.RemoveAt(index);
    }

    void SetQuestionText(string text)
    {
        Debug.Log("2. SetQuestionText()");
        questionText.text = text;
    }

    void SetButtonText()
    {
        Debug.Log("3. SetButtonText()");
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

    void SetButtonColor(int index, Color color)
    {
        answerBtns[index].GetComponent<Image>().color = color;
    }

    void SetButtonDefault()
    {
        for (int i = 0; i < answerBtns.Length; i++)
        {
            SetButtonColor(i, Color.white);
        }
        SetButtonState(true);
    }

    // 퀴즈 출력
    void DisplayQuestion()
    {
        GetRandomQuestion();
        SetQuestionText(currentQuestion.Question);
        SetButtonText();

        SetButtonDefault();
    }

    public void OnSelectedButton(int index)
    {
        if (questions.Count == 0)
        {
            Debug.Log("questsion 끝남");
            GameManager.instance.IsGameOver = true;
            return;
        }

        SetButtonState(false);
        if (currentQuestion.CorrectAnswerIndex == index)
        {
            SetQuestionText("The Answer is \n" + currentQuestion.GetAnswer(currentQuestion.CorrectAnswerIndex));
            SetButtonColor(index, Color.red);
        }
        else
        {
            SetQuestionText("Correct!");
        }
        SetButtonColor(currentQuestion.CorrectAnswerIndex, Color.green);

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