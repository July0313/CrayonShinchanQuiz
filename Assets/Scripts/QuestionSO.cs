using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 4)]
    [SerializeField] string question = "이곳에 질문을 작성하세요";
    [Header("정답")]
    [SerializeField] int correctAnswerIndex;
    [SerializeField] string[] answers = new string[4];

    // 프로퍼티
    public string Question { get { return question; } }
    public int CorrectAnswerIndex { get { return correctAnswerIndex; } }

    public string GetAnswer(int index)
    {
        return answers[index];
    }
}
