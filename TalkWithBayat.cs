using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

public class TalkWithBayat : MonoBehaviour
{
    public GameObject OurCharacter;
    public GameObject Bayat;
    public GameObject TalkPanel;
    public TextMeshProUGUI text;
    public string[] lines;
    public float textSpeed;
    private int index;
    public int ClickCount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowTalkPanel();
            OurCharacter.SetActive(true);
        }
    }
    public void ShowTalkPanel()
    {
        TalkPanel.SetActive(true);
    }
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
            if (ClickCount == 11)
            {
                TalkPanel.SetActive(false);
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
            if (ClickCount == 11)
            {
                TalkPanel.SetActive(false);
                Invoke("DeleteClickCount", 1f);
            }
           
        }
        
        if (ClickCount == 1)
        {
            OurCharacter.SetActive(false);
            Bayat.SetActive(true);
        }
        else if (ClickCount == 2)
        {
            OurCharacter.SetActive(true);
            Bayat.SetActive(false);
        }
        else if (ClickCount == 3)
        {
            OurCharacter.SetActive(false);
            Bayat.SetActive(true);
        }
        else if (ClickCount == 4)
        {
            OurCharacter.SetActive(true);
            Bayat.SetActive(false);
        }
        else if (ClickCount == 5)
        {
            OurCharacter.SetActive(false);
            Bayat.SetActive(true);
        }
        else if (ClickCount == 6)
        {
            OurCharacter.SetActive(false);
            Bayat.SetActive(true);
        }
        else if (ClickCount == 7)
        {
            OurCharacter.SetActive(true);
            Bayat.SetActive(false);
        }
        else if (ClickCount == 8)
        {
            OurCharacter.SetActive(false);
            Bayat.SetActive(true);
        }
        else if (ClickCount == 9)
        {
            OurCharacter.SetActive(true);
            Bayat.SetActive(false);
        }
        else if (ClickCount == 10)
        {
            OurCharacter.SetActive(false);
            Bayat.SetActive(true);
        }
        else if(ClickCount == 11) 
        {
            Bayat.SetActive(false);
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
