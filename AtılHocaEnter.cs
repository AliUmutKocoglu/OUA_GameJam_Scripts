using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AtılHocaEnter : MonoBehaviour
{
    public GameObject QuestionPanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowQuestionPanel();
        }
    }
    public void ShowQuestionPanel()
    {
        QuestionPanel.SetActive(true);
    }
    public void CloseQuestionPanel()
    {
        QuestionPanel.SetActive(false);
    }
    public void AcceptQuestion()
    {
        SceneManager.LoadScene(7);
    }
}
