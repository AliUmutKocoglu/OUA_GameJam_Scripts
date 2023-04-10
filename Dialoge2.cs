using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Dialoge2 : MonoBehaviour
{
    public GameObject AtilHoca;
    public GameObject OurCharacter;
    public TextMeshProUGUI text;
    public string[] lines;
    public float textSpeed;
    private int index;
    public int ClickCount = 0;

    void Start()
    {
        text.text = string.Empty;
        StartDialoge();

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
            if (ClickCount == 13)
            {
                SceneManager.LoadScene(10);
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
            if (ClickCount == 13)
            {
                SceneManager.LoadScene(10);
                Invoke("DeleteClickCount", 1f);
            }
        }
        if (ClickCount <= 3)
        {
            AtilHoca.SetActive(true);
        }
        else if (ClickCount == 4)
        {
            OurCharacter.SetActive(true);
            AtilHoca.SetActive(false);
        }
        else if (ClickCount == 5)
        {
            OurCharacter.SetActive(false);
            AtilHoca.SetActive(true);
        }
        else if (ClickCount == 6)
        {
            OurCharacter.SetActive(true);
            AtilHoca.SetActive(false);
        }
        else if (ClickCount == 7)
        {
            OurCharacter.SetActive(false);
            AtilHoca.SetActive(true);
        }
        else if (ClickCount == 8)
        {
            OurCharacter.SetActive(true);
            AtilHoca.SetActive(false);
        }
        else if (ClickCount == 9)
        {
            OurCharacter.SetActive(false);
            AtilHoca.SetActive(true);
        }
        else if (ClickCount == 10)
        {
            OurCharacter.SetActive(false);
            AtilHoca.SetActive(true);
        }
        else if (ClickCount == 11)
        {
            OurCharacter.SetActive(true);
            AtilHoca.SetActive(false);
        }
        else if (ClickCount == 12)
        {
            OurCharacter.SetActive(false);
            AtilHoca.SetActive(true);
        }
    }

    void StartDialoge()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach (char s in lines[index].ToCharArray())
        {
            text.text += s;
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
    void DeleteClickCount()
    {
        ClickCount = 0;
    }
}
