using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    public void HandleBackButtonClicked()
    {
        MenuManager.LoadMenu(MenuName.Main);
    }
}
