using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizTimer : MonoBehaviour
{
    float maxTime = 30f;
    float timer = 0f;

    Quiz quiz;
    Slider quizTimer;

    private void Awake()
    {
        quiz = GetComponentInParent<Quiz>();
        quizTimer = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        timer = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        quizTimer.value = timer / maxTime;

        if (timer <= 0f)
        {
            quiz.OnButtonSelected(-1);
        }
    }
}
