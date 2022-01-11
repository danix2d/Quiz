using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleAI : MonoBehaviour
{
    public Player player;
    public List<Button> buttons = new List<Button>();
    
    public int num;
    private float timer = 0;
    private int seconds = 0;
    private bool makeMove = false;
    private bool pause;

    public void Update()
    {
        MakeMove();
    }

    public void MakeMove()
    {
        if(pause){return;}

        if(timer == 0){
            num = Random.Range(5,15);
        }

        timer += Time.deltaTime;
        seconds = (int)timer % 60;

        if(seconds == num){
            ResetAI();
            int rand = Random.Range(0, buttons.Count);
            buttons[rand].GetComponent<Answer>().SelectAnswer(2);
            buttons[rand].GetComponent<BtnOnTap>().DoAnim();
        }
    }

    public void PauseAI(){
        pause = true;
    }

    public void ResetAI(){
        pause = false;
        num = 0;
        timer = 0;
    }
}
