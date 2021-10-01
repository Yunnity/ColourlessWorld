using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    static List<Player> playerDeathInvokers = new List<Player>();
    static List<UnityAction> playerDeathListeners = new List<UnityAction>();

    static DestructibleBlocks brokenBlockInvoker;
    static UnityAction<AudioClips> brokenBlockListener;

    static Player playerSFXInvoker;
    static UnityAction<AudioClips> playerSFXListener;

    static General gamePausedInvoker;
    static UnityAction gamePausedListener;

    static PauseMenu gameResumedInvoker;
    static UnityAction gameResumedListener;

    static General destroyPuzzleInvoker;
    static List<UnityAction> destroyPuzzleListeners = new List<UnityAction>();


    static General generalSFXInvoker;
    static UnityAction<AudioClips> generalSFXListener;

    static List<PuzzlePaintTiles> colourTouchedInvokers = new List<PuzzlePaintTiles>();
    static List<UnityAction<string>> colourTouchedListeners = new List<UnityAction<string>>();

    static General layerIncrementInvoker;
    static List<UnityAction> layerIncrementListeners = new List<UnityAction>();

    static List<PuzzlePaintTiles> blockSelectedInvokers = new List<PuzzlePaintTiles>();
    static List<UnityAction<AudioClips>> blockSelectedListeners = new List<UnityAction<AudioClips>>();

    static OneOneFinish oneOneClearedInvoker;
    static UnityAction oneOneClearedListener;

    static OneTwoFinish oneTwoClearedInvoker;
    static UnityAction oneTwoClearedListener;

    static OneThreeFinish oneThreeClearedInvoker;
    static UnityAction oneThreeClearedListener;

    static LevelSelect levelSelectSFXInvoker;
    static UnityAction<AudioClips> levelSelectSFXListener;


    static StandardPaint levelClearedInvoker;
    static UnityAction<AudioClips> levelClearedListener;

    public static void AddPlayerDeathInvoker(Player invoker)
    {
        playerDeathInvokers.Add(invoker);
        foreach(UnityAction listener in playerDeathListeners)
        {
            invoker.AddPlayerDeathListener(listener);
        }
    }

    public static void AddPlayerDeathListener(UnityAction listener)
    {
        playerDeathListeners.Add(listener);
        foreach(Player invoker in playerDeathInvokers)
        {
            invoker.AddPlayerDeathListener(listener);
        }
    }

    public static void AddBrokenBlockInvoker(DestructibleBlocks invoker)
    {
        brokenBlockInvoker = invoker;
        if(brokenBlockInvoker != null)
        {
            brokenBlockInvoker.AddBrokenBlockListener(brokenBlockListener);
        }
    }

    public static void AddBrokenBlockListener(UnityAction<AudioClips> listener)
    {
        brokenBlockListener = listener;
        if(brokenBlockInvoker != null)
        {
            brokenBlockInvoker.AddBrokenBlockListener(listener);
        }
    }

    public static void AddPlayerSFXInvoker(Player invoker)
    {
        playerSFXInvoker = invoker;
        if(playerSFXInvoker != null)
        {
            playerSFXInvoker.AddPlayerSFXListener(playerSFXListener);
        }
    }

    public static void AddPlayerSFXListener(UnityAction<AudioClips> listener)
    {
        playerSFXListener = listener;
        if (playerSFXInvoker != null)
        {
            playerSFXInvoker.AddPlayerSFXListener(playerSFXListener);
        }
    }

    public static void AddGamePausedInvoker(General invoker)
    {
        gamePausedInvoker = invoker;
        if(gamePausedInvoker != null)
        {
            gamePausedInvoker.AddGamePausedListener(gamePausedListener);
        }
    }

    public static void AddGamePausedListener(UnityAction listener)
    {
        gamePausedListener = listener;
        if(gamePausedInvoker != null)
        {
            gamePausedInvoker.AddGamePausedListener(listener);
        }
    }

    public static void AddGameResumedInvoker(PauseMenu invoker)
    {
        gameResumedInvoker = invoker;
        if(gameResumedInvoker != null)
        {
            gameResumedInvoker.AddGameResumedListener(gameResumedListener);
        }
    }

    public static void AddGameResumedListener(UnityAction listener)
    {
        gameResumedListener = listener;
        if(gameResumedInvoker != null)
        {
            gameResumedInvoker.AddGameResumedListener(listener);
        }
    }

    public static void AddDestroyPuzzleInvoker(General invoker)
    {
        destroyPuzzleInvoker = invoker;
        foreach(UnityAction listener in destroyPuzzleListeners)
        {
            destroyPuzzleInvoker.AddDestroyPuzzleListener(listener);
        }
    }

    public static void AddDestroyPuzzleListener(UnityAction listener)
    {
        destroyPuzzleListeners.Add(listener);
        if (destroyPuzzleInvoker != null)
        {
            destroyPuzzleInvoker.AddDestroyPuzzleListener(listener);
        }
    }

    public static void AddGeneralSFXInvoker(General invoker)
    {
        generalSFXInvoker = invoker;
        if(generalSFXInvoker != null)
        {
            generalSFXInvoker.AddGeneralSFXListener(generalSFXListener);
        }
    }

    public static void AddGeneralSFXListener(UnityAction<AudioClips> listener)
    {
        generalSFXListener = listener;
        if (generalSFXInvoker != null)
        {
            generalSFXInvoker.AddGeneralSFXListener(generalSFXListener);
        }
    }

    public static void AddColourTouchedInvoker(PuzzlePaintTiles invoker)
    {
        colourTouchedInvokers.Add(invoker);
        foreach(UnityAction<string> listener in colourTouchedListeners)
        {
            invoker.AddColourTouchedListener(listener);
        }
    }

    public static void AddColourTouchedListener(UnityAction<string> listener)
    {
        colourTouchedListeners.Add(listener);
        foreach(PuzzlePaintTiles invoker in colourTouchedInvokers)
        {
            invoker.AddColourTouchedListener(listener);
        }
    }

    public static void AddBlockSelectedInvoker(PuzzlePaintTiles invoker)
    {
        blockSelectedInvokers.Add(invoker);
        foreach(UnityAction<AudioClips> listener in blockSelectedListeners)
        {
            invoker.AddBlockSelectedListener(listener);
        }
    }

    public static void AddBlockSelectedListener(UnityAction<AudioClips> listener)
    {
        blockSelectedListeners.Add(listener);
        foreach(PuzzlePaintTiles invoker in blockSelectedInvokers)
        {
            invoker.AddBlockSelectedListener(listener);
        }
    }

    public static void AddOneOneClearedInvoker(OneOneFinish invoker)
    {
        oneOneClearedInvoker = invoker;
        if(oneOneClearedInvoker != null)
        {
            oneOneClearedInvoker.AddOneOneClearedEventListener(oneOneClearedListener);
        }
    }

    public static void AddOneOneClearedListener(UnityAction listener)
    {
        oneOneClearedListener = listener;
        if(oneOneClearedInvoker != null)
        {
            oneOneClearedInvoker.AddOneOneClearedEventListener(listener);
        }
    }

    public static void AddOneTwoClearedInvoker(OneTwoFinish invoker)
    {
        oneTwoClearedInvoker = invoker;
        if(oneTwoClearedInvoker != null)
        {
            oneTwoClearedInvoker.AddOneTwoClearedListener(oneTwoClearedListener);
        }
    }

    public static void AddOneTwoClearedListener(UnityAction listener)
    {
        oneTwoClearedListener = listener;
        if(oneTwoClearedInvoker != null)
        {
            oneTwoClearedInvoker.AddOneTwoClearedListener(listener);
        }
    }

    public static void AddOneThreeClearedInvoker(OneThreeFinish invoker)
    {
        oneThreeClearedInvoker = invoker;
        if(oneThreeClearedInvoker != null)
        {
            oneThreeClearedInvoker.AddOneThreeClearedListener(oneThreeClearedListener);
        }
    }

    public static void AddOneThreeClearedListener(UnityAction listener)
    {
        oneThreeClearedListener = listener;
        if(oneThreeClearedInvoker != null)
        {
            oneThreeClearedInvoker.AddOneThreeClearedListener(listener);
        }
    }

    public static void AddLevelSelectInvoker(LevelSelect invoker)
    {
        levelSelectSFXInvoker = invoker;
        if(levelSelectSFXInvoker != null)
        {
            levelSelectSFXInvoker.AddLevelSelectListener(levelSelectSFXListener);
        }
    }

    public static void AddLevelSelectListener(UnityAction<AudioClips> listener)
    {
        levelSelectSFXListener = listener;
        if(levelSelectSFXInvoker != null)
        {
            levelSelectSFXInvoker.AddLevelSelectListener(listener);
        }
    }

    public static void AddLayerIncrementInvoker(General invoker)
    {
        layerIncrementInvoker = invoker;
        if(layerIncrementInvoker != null)
        {
            foreach (UnityAction listener in layerIncrementListeners)
            {
                layerIncrementInvoker.AddIncrementLayerListener(listener);
            }
        }
    }

    public static void AddLayerIncrementListener(UnityAction listener)
    {
        layerIncrementListeners.Add(listener);
        if(layerIncrementInvoker != null)
        {
            layerIncrementInvoker.AddIncrementLayerListener(listener);
        }
    }

    public static void AddLevelClearedInvoker(StandardPaint invoker)
    {
        levelClearedInvoker = invoker;
        if(levelClearedInvoker != null)
        {
            levelClearedInvoker.AddLevelClearedListener(levelClearedListener);
        }
    }

    public static void AddLevelClearedListener(UnityAction<AudioClips> listener)
    {
        levelClearedListener = listener;
        if (levelClearedInvoker != null)
        {
            levelClearedInvoker.AddLevelClearedListener(levelClearedListener);
        }
    }
}
