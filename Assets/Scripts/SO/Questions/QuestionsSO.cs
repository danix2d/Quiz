using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "CreateQuestionsSO",fileName ="Question")]
public class QuestionsSO : ScriptableObject
{
    public string question;
    public int correctAnswer;
    public List<string> answers;
    
    [Range(1, 3)]
    public int difficulty = 1;
}
