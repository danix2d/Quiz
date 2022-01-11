using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public FloatVariable timer;
    public GameEvent timeEnded;
    public TMP_Text timerText;
    public Image progressBar;
    private bool stopTimer;
    private int seconds = 0;

    private void Start() {
        timer.value = 60.0f;
    }

    void Update()
    {
        TimeDown();
    }

    public void StopTimer()
    {
        stopTimer = true;
    }

    public void StartTimer()
    {
        timer.value = 60.0f;
        stopTimer = false;
        progressBar.fillAmount = 1;
    }

    private void TimeDown()
    {
        if(stopTimer){return;}

        if(timer.value > 0) 
        {
            timer.value -= Time.deltaTime;
            seconds = (int)timer.value % 60;
            timerText.text = seconds.ToString();

            progressBar.fillAmount -= 1.0f / 60 * Time.deltaTime;
        }

        if(timer.value < 0)
        {
            timeEnded.Raise();
        }
    }
}
