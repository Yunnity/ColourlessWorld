using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class StandardPaint : MonoBehaviour
{
    LevelClearedEvent levelClearedEvent;

    public virtual void Start()
    {
        levelClearedEvent = new LevelClearedEvent();
        EventManager.AddLevelClearedInvoker(this);
    }
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        levelClearedEvent.Invoke(AudioClips.LevelCompleted);
        MenuManager.LoadMenu(MenuName.LevelSelect);
    }

    public void AddLevelClearedListener(UnityAction<AudioClips> listener)
    {
        levelClearedEvent.AddListener(listener);
    }
}
