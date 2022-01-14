using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BtnOnTap : MonoBehaviour
{
    public float duration;
    public UI_Animations anim;
    public GameEvent Event;

    public void DoAnim()
    {
        if(anim.popUP)
        {
            transform.localScale = Vector3.one/2.5f;
        }

        if(anim.useCustomEase)
        {
            transform.DOScale(anim.scale, duration).SetEase(anim.customEase).OnComplete(RaiseEvent);
        }else{
            transform.DOScale(anim.scale, duration).SetEase(anim.ease);
        }
    }

    private void RaiseEvent()
    {
        if(Event == null){return;}
        Event.Raise();
    }
}