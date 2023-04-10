using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

public class TolgayHocaDialog : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject TolgayHoca;
    public GameObject OurCharacter;
    public string[] lines;
    public float textSpeed;
    private int index;
    public int ClickCount = 0;


    void Start()
    {
        text.text = string.Empty;
        StartDialogue();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickCount++;
            if (text.text == lines[index])
            {
                SkipLine();
            }
            else
            {
                StopAllCoroutines();
                text.text = lines[index];
            }
            if (ClickCount == 1)
            {
                SceneManager.LoadScene(28);
                Invoke("DeleteClickCount", 1f);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            ClickCount++;
            if (text.text == lines[index])
            {
                SkipLine();
            }
            else
            {
                StopAllCoroutines();
                text.text = lines[index];
            }
            if (ClickCount == 1)
            {
                SceneManager.LoadScene(28);
                Invoke("DeleteClickCount", 1f);
            }
        }

        if (ClickCount == 0)
        {
            TolgayHoca.SetActive(true);
        }
        if (ClickCount == 1)
        {
            TolgayHoca.SetActive(false);
        }


    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void SkipLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
