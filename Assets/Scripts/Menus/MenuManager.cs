using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    public static void LoadMenu(MenuName menuName)
    {
        switch(menuName)
        {
            case MenuName.Main:
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.Help:
                SceneManager.LoadScene("HelpMenu");
                break;
            case MenuName.LevelSelect:
                SceneManager.LoadScene("LevelSelect");
                break;
            case MenuName.Pause:
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
            case MenuName.One:
                SceneManager.LoadScene("1-1");
                break;
            case MenuName.Two:
                SceneManager.LoadScene("1-2");
                break;
            case MenuName.Three:
                SceneManager.LoadScene("1-3");
                break;
            case MenuName.Four:
                SceneManager.LoadScene("1-4");
                break;
        }
    }
}
