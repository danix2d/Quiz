using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


[CreateAssetMenu]
public class UI_Animations : ScriptableObject
{
    public AnimationCurve customEase;
    public Ease ease;
    public Vector3 scale;
    public Vector3 position;

    public bool popUP;
    public bool autoAnimate;
    public bool loopAnim;
    public bool useCustomEase;
}
