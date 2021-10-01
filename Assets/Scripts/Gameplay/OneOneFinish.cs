using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OneOneFinish : StandardPaint
{
    OneOneClearedEvent oneOneClearedEvent;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        oneOneClearedEvent = new OneOneClearedEvent();
        EventManager.AddOneOneClearedInvoker(this);
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
        oneOneClearedEvent.Invoke();
    }

    public void AddOneOneClearedEventListener(UnityAction listener)
    {
        oneOneClearedEvent.AddListener(listener);
    }
}
