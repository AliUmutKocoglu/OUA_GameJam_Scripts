using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeckinHocaQuestionScript : MonoBehaviour
{
    private int correctAnswerIndex;
    public GameObject correctPanel, wrongPanel;
    public SeckinHocaQuestions[] questions;
    public TMP_Text questionsText;
    public TMP_Text[] buttonText;
    private int currentQuestion = 0;
    void Start()
    {
        SetQuestion();
    }
    private void SetQuestion()
    {
        int questionIndex = currentQuestion;
        questionsText.text = questions[questionIndex].questionText;
        for(int i =0;i<buttonText.Length;i++) 
        {
            buttonText[i].text = questions[questionIndex].answers[i];
        }
        correctAnswerIndex= questions[questionIndex].correctAnswerIdx;
        currentQuestion++;
        if (questionIndex >= 5)
        {
            SceneManager.LoadScene(21);
        }
    }
    public void AnswerButton(int answerIndex)
    {
        if(answerIndex==correctAnswerIndex)
        {
            correctPanel.SetActive(true);
        }
        else
        {
            wrongPanel.SetActive(true);
        }
    } 
    public void PanelButton(bool isTrue)
    {
        if(isTrue)
        {
            correctPanel.SetActive(false);
            SetQuestion();
        }
        else
        {
            wrongPanel.SetActive(false);
        }
    }
}
