using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class OneTwo : General
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        answerList.Add("Green");
        answerList.Add("Red");
        answerList.Add("Yellow");
        EventManager.AddColourTouchedListener(AddColourToList);
        GameObject.FindGameObjectWithTag("Trial1").AddComponent<PuzzleBlocks>();
    }

    void AddColourToList(string colour)
    {
        submittedList.Add(colour);
        if (!firstCleared && submittedList.Count == 3)
        {
            if (answerList.SequenceEqual(submittedList))
            {
                destroyPuzzleEvent.Invoke();
                generalSFX.Invoke(AudioClips.Cleared);
                firstCleared = true;
                answerList.Clear();
                answerList.Add("Orange");
                answerList.Add("Yellow");
                answerList.Add("Indigo");
                answerList.Add("Violet");
                GameObject.FindGameObjectWithTag("Trial2").AddComponent<PuzzleBlocks>();
                incrementLayerEvent.Invoke();
            }
            else
            {
                generalSFX.Invoke(AudioClips.Failed);
            }
            submittedList.Clear();
        }
        else if (firstCleared && !secondCleared && submittedList.Count == 4)
        {
            if (answerList.SequenceEqual(submittedList))
            {
                destroyPuzzleEvent.Invoke();
                generalSFX.Invoke(AudioClips.Cleared);
                secondCleared = true;
                answerList.Clear();
                answerList.Add("Violet");
                answerList.Add("Green");
                answerList.Add("Red");
                GameObject.FindGameObjectWithTag("Puzzle").AddComponent<PuzzleBlocks>();
                incrementLayerEvent.Invoke();
            }
            else
            {
                generalSFX.Invoke(AudioClips.Failed);
            }
            submittedList.Clear();
        }
        else if(secondCleared && submittedList.Count == 3)
        {
            if(submittedList.SequenceEqual(answerList))
            {
                generalSFX.Invoke(AudioClips.Cleared);
                destroyPuzzleEvent.Invoke();
                incrementLayerEvent.Invoke();
            }
            else
            {
                generalSFX.Invoke(AudioClips.Failed);
                submittedList.Clear();
            }
        }
    }
}
