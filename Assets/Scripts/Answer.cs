using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Answer : MonoBehaviour
{
    public Player player;
    public Player playerAI;
    public FloatVariable timer;
    public IntVariable currentQestion;
    public Image button;
    public GameEvent eventAnswerSelected;
    public TMP_Text answer;
    public bool isCorrectAnswer;

    public Color color;

    private void Start() 
    {
        button = GetComponent<Image>();
        button.color = color;
    }

    public void SelectAnswer(int id)
    {
        eventAnswerSelected.Raise();

        if(id == player.playerID)
        {
            if(isCorrectAnswer)
            {
                button.color = Color.green;
                GivePoints(player,playerAI,true);
            }else{
                button.color = Color.red;
                GivePoints(playerAI,player,false);
            }
        }else{
            if(isCorrectAnswer)
            {
                button.color = Color.green;
                GivePoints(playerAI,player,true);
            }else{
                button.color = Color.red;
                GivePoints(player,playerAI,false);
            }
        }
    }

    private void GivePoints(Player win, Player lost, bool correct)
    {
        if(correct)
        {
            win.score += 100 + (int)timer.value;
        }else{
            win.score += 50;
        }
    }
    
    public void ResetButton()
    {
        button.color = color;
    }
}
