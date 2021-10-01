using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTracker : MonoBehaviour
{
    public static bool initialized = false;
    public static bool firstCleared = false;
    public static bool secondCleared = false;
    public static bool thirdCleared = false;

    // Start is called before the first frame update
    void Awake()
    {
        if(!initialized)
        {
            Initialize();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Initialize()
    {
        initialized = true;
        EventManager.AddOneOneClearedListener(ClearedOneOne);
        EventManager.AddOneTwoClearedListener(ClearedOneTwo);
        EventManager.AddOneThreeClearedListener(ClearedOneThree);
    }

    void ClearedOneOne()
    {
        firstCleared = true;
    }

    void ClearedOneTwo()
    {
        secondCleared = true;
    }

    void ClearedOneThree()
    {
        thirdCleared = true;
    }
}
