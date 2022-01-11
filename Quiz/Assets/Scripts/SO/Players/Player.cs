using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Player : ScriptableObject
{
    public int playerID;
    public int score;
    public List<Image> pointsImg = new List<Image>();
    public Sprite greenPoint;
    public Sprite redPoint;

    public void OnEnable()
    {
        score = 0;
    }
}
