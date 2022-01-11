using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QAManager : MonoBehaviour
{
    public GameEvent gameOver;
    public List<QuestionsSO> questionsSOList;
    private List<QuestionsSO> questionsList = new List<QuestionsSO>();

    public TMP_Text qaCounterTxt;
    public TMP_Text questionText;
    
    public List<GameObject> buttons = new List<GameObject>();

    private List<Answer> answers = new List<Answer>();
    private List<Button> buttonPanels = new List<Button>();

    public IntVariable currentQestion;

    private void Start() 
    {
        currentQestion.value = 0;

        while (questionsList.Count < 10)
        {
            int rand = Random.Range(0, questionsSOList.Count);

            if(questionsList.Contains(questionsSOList[rand]))
            {
                continue;
            }else{
                questionsList.Add(questionsSOList[rand]);
            }
        }

        for (int i = 0; i < buttons.Count; i++)
        {
            buttonPanels.Add(buttons[i].GetComponent<Button>());
        }

        BuildQuestion();

    }

    public void BuildQuestion()
    {
        if(currentQestion.value == questionsList.Count)
        {
            gameOver.Raise();
            DisableButtons();
            return;
        }

        qaCounterTxt.text = $"{currentQestion.value+1} of {questionsList.Count}";
        questionText.text = questionsList[currentQestion.value].question;

        for (int i = 0; i < buttons.Count; i++) 
        {
            GameObject temp = buttons[i];
            int randomIndex = Random.Range(i, buttons.Count);
            buttons[i] = buttons[randomIndex];
            buttons[randomIndex] = temp;
        }

        answers.Clear();

        for (int i = 0; i < buttons.Count; i++)
        {

            answers.Add(buttons[i].GetComponent<Answer>());

            answers[i].isCorrectAnswer = false;
            answers[i].answer.text = questionsList[currentQestion.value].answers[i];

            if(i == questionsList[currentQestion.value].correctAnswer)
            {
                answers[i].isCorrectAnswer = true;
            }

            buttonPanels[i].interactable = true;
        }

        currentQestion.value++;
    }

    public void DisableButtons()
    {
        for (int i = 0; i < buttonPanels.Count; i++)
        {
            buttonPanels[i].interactable = false;
        }
    }

}

