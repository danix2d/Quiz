using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public Player player;
    public TMP_Text scoreTxt;
    
    public void UpdateScore()
    {
        scoreTxt.text = player.score.ToString();
    }
}
