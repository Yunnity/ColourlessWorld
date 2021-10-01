using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class General : MonoBehaviour
{
    GamePausedEvent gamePausedEvent;
    protected DestroyPuzzleEvent destroyPuzzleEvent;
    protected IncrementLayerEvent incrementLayerEvent;
    protected GeneralSFX generalSFX;
    protected List<string> answerList = new List<string>();
    protected List<string> submittedList = new List<string>();
    protected bool firstCleared = false;
    protected bool secondCleared = false;

    protected virtual void Start()
    {
        gamePausedEvent = new GamePausedEvent();
        destroyPuzzleEvent = new DestroyPuzzleEvent();
        incrementLayerEvent = new IncrementLayerEvent();
        generalSFX = new GeneralSFX();
        EventManager.AddGeneralSFXInvoker(this);
        EventManager.AddGamePausedInvoker(this);
        EventManager.AddDestroyPuzzleInvoker(this);
        EventManager.AddLayerIncrementInvoker(this);
    }

    protected virtual void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameObject.FindGameObjectWithTag("Pause") == null)
            {
                Instantiate(Resources.Load("PauseMenu"));
                gamePausedEvent.Invoke();
            }
        }
    }

    public void AddGamePausedListener(UnityAction listener)
    {
        gamePausedEvent.AddListener(listener);
    }

    public void AddDestroyPuzzleListener(UnityAction listener)
    {
        destroyPuzzleEvent.AddListener(listener);
    }

    public void AddGeneralSFXListener(UnityAction<AudioClips> listener)
    {
        generalSFX.AddListener(listener);
    }

    public void AddIncrementLayerListener(UnityAction listener)
    {
        incrementLayerEvent.AddListener(listener);
    }
}
