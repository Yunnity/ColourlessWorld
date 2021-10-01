using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelSelect : MonoBehaviour
{
    [SerializeField]
    GameObject prefabLockedLevel;

    Vector3 levelLockedPosition = Vector3.zero;
    LevelSelectSFX levelSelectSFX;

    void Start()
    {
        levelLockedPosition.y += ScreenUtils.ScreenBottom / 2;
        levelSelectSFX = new LevelSelectSFX();
        EventManager.AddLevelSelectInvoker(this);
    }

    public void HandleBackButtonClicked()
    {
        MenuManager.LoadMenu(MenuName.Main);
    }

    public void HandleOneClicked()
    {
        MenuManager.LoadMenu(MenuName.One);
        levelSelectSFX.Invoke(AudioClips.LevelSelect);
    }
    public void HandleTwoClicked()
    {
        if (LevelTracker.firstCleared)
        {
            MenuManager.LoadMenu(MenuName.Two);
            levelSelectSFX.Invoke(AudioClips.LevelSelect);
        }
        else
        {
            Destroy(GameObject.FindGameObjectWithTag("LevelLocked"));
            Instantiate(prefabLockedLevel, levelLockedPosition, Quaternion.identity);
            levelSelectSFX.Invoke(AudioClips.LevelLocked);
        }
    }
    public void HandleThreeClicked()
    {
        if(LevelTracker.secondCleared)
        {
            MenuManager.LoadMenu(MenuName.Three);
            levelSelectSFX.Invoke(AudioClips.LevelSelect);
        }
        else
        {
            Destroy(GameObject.FindGameObjectWithTag("LevelLocked"));
            Instantiate(prefabLockedLevel, levelLockedPosition, Quaternion.identity);
            levelSelectSFX.Invoke(AudioClips.LevelLocked);
        }
    }
    public void HandleFourClicked()
    {
        if(LevelTracker.thirdCleared)
        {
            MenuManager.LoadMenu(MenuName.Four);
            levelSelectSFX.Invoke(AudioClips.LevelSelect);
        }
        else
        {
            Destroy(GameObject.FindGameObjectWithTag("LevelLocked"));
            Instantiate(prefabLockedLevel, levelLockedPosition, Quaternion.identity);
            levelSelectSFX.Invoke(AudioClips.LevelLocked);
        }
        
    }

    public void AddLevelSelectListener(UnityAction<AudioClips> listener)
    {
        levelSelectSFX.AddListener(listener);
    }
}
