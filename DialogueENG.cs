using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueENG : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject AtilHoca;
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
        }

        if (ClickCount == 0)
        {
            AtilHoca.SetActive(true);
        }
        
        if (ClickCount == 2)
        {
            AtilHoca.SetActive(false);
            SceneManager.LoadScene(32);
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
