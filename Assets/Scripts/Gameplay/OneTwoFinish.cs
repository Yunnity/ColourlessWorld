using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OneTwoFinish : StandardPaint
{
    OneTwoClearedEvent oneTwoClearedEvent;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        oneTwoClearedEvent = new OneTwoClearedEvent();
        EventManager.AddOneTwoClearedInvoker(this);
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        oneTwoClearedEvent.Invoke();
    }

    public void AddOneTwoClearedListener(UnityAction listener)
    {
        oneTwoClearedEvent.AddListener(listener);
    }
}
