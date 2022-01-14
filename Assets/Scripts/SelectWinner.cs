using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWinner : MonoBehaviour
{
    public Player player;
    public Player AI;

    public GameObject playerFrame;
    public GameObject AIFrame;

    public void OnEnable()
    {
        if(player.score > AI.score)
        {
            playerFrame.SetActive(true);
        }else{
            AIFrame.SetActive(true);
        }
    }
}
