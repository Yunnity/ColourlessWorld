using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void HandlePlayButtonClicked()
    {
        MenuManager.LoadMenu(MenuName.LevelSelect);
    }

    public void HandleHelpButtonClicked()
    {
        MenuManager.LoadMenu(MenuName.Help);
    }

    public void HandleExitButtonClicked()
    {
        Application.Quit();
    }
}
