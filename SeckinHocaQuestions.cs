using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Question",menuName ="Question")]
public class SeckinHocaQuestions : ScriptableObject
{
    public string questionText;
    public string[] answers;
    public int correctAnswerIdx;
}
