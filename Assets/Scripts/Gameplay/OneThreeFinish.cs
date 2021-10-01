using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OneThreeFinish : StandardPaint
{
    OneThreeClearedEvent oneThreeClearedEvent;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        oneThreeClearedEvent = new OneThreeClearedEvent();
        EventManager.AddOneThreeClearedInvoker(this);
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        oneThreeClearedEvent.Invoke();
    }

    public void AddOneThreeClearedListener(UnityAction listener)
    {
        oneThreeClearedEvent.AddListener(listener);
    }
}
