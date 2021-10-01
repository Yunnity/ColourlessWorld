using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    GameResumedEvent gameResumedEvent;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        gameResumedEvent = new GameResumedEvent();
        EventManager.AddGameResumedInvoker(this);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            Destroy(gameObject);
            gameResumedEvent.Invoke();
        }
    }

    public void HandleResumeButtonClicked()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
        gameResumedEvent.Invoke();
    }

    public void HandleQuitButtonClicked()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.LoadMenu(MenuName.LevelSelect);
        gameResumedEvent.Invoke();
    }

    public void AddGameResumedListener(UnityAction listener)
    {
        gameResumedEvent.AddListener(listener);
    }
}
