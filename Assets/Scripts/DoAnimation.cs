using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoAnimation : MonoBehaviour
{
    public float duration;
    public float delay;
    public UI_Animations anim;
    public GameEvent Event;
    private TweenParams tParms;

    private void OnEnable() 
    {
        if(anim.autoAnimate)
        {
            DoAnim();
        }
    }

    public void DoAnim()
    {
        if(anim.loopAnim)
        {
            tParms = new TweenParams().SetEase(anim.ease).SetDelay(delay).SetLoops(-1, LoopType.Yoyo).OnComplete(RaiseEvent);
        }else{
            tParms = new TweenParams().SetEase(anim.ease).SetDelay(delay).OnComplete(RaiseEvent);
        }

        if(anim.position != Vector3.zero)
        {
            transform.DOLocalMove(anim.position,duration).SetAs(tParms);
        }
        
        if(anim.popUP)
        {
            transform.localScale = Vector3.zero;
        }

        if(anim.useCustomEase)
        {
            transform.DOScale(anim.scale, duration).SetAs(tParms).SetEase(anim.customEase);
        }else{
            transform.DOScale(anim.scale, duration).SetAs(tParms);
        }
        
    }

    //Raise Event on animation complete
    private void RaiseEvent()
    {
        if(Event == null){return;}

        Event.Raise();
    }

    // private void Disabled()
    // {
    //     this.gameObject.SetActive(false);
    // }
}
