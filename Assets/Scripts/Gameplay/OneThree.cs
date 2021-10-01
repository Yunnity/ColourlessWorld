using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OneThree : General
{
    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        answerList.Add("Violet");
        answerList.Add("Indigo");
        answerList.Add("Blue");
        EventManager.AddColourTouchedListener(AddColourToList);
    }
    void AddColourToList(string colour)
    {
        submittedList.Add(colour);
        if(submittedList.Count == 3 && !firstCleared)
        {
            if (submittedList.SequenceEqual(answerList))
            {
                generalSFX.Invoke(AudioClips.Cleared);
                destroyPuzzleEvent.Invoke();
                incrementLayerEvent.Invoke();
                firstCleared = true;
                answerList.Clear();
                answerList.Add("Red");
                answerList.Add("Green");
                answerList.Add("Blue");
                answerList.Add("Black");
                GameObject.FindGameObjectWithTag("Trial2").AddComponent<PuzzleBlocks>();
            }
            else
            {
                generalSFX.Invoke(AudioClips.Failed);                
            }
            submittedList.Clear();
        }
        else if (firstCleared && !secondCleared && submittedList.Count == 4)
        {
            if(submittedList.SequenceEqual(answerList))
            {
                generalSFX.Invoke(AudioClips.Cleared);
                destroyPuzzleEvent.Invoke();
                incrementLayerEvent.Invoke();
                answerList.Clear();
                submittedList.Clear();
                secondCleared = true;
                GameObject.FindGameObjectWithTag("Puzzle").AddComponent<PuzzleBlocks>();
                answerList.Add("Violet");
                answerList.Add("Indigo");
                answerList.Add("Blue");
                answerList.Add("Green");
                answerList.Add("Yellow");
                answerList.Add("Orange");
                answerList.Add("Red");
            }
            else
            {
                submittedList.Clear();
                generalSFX.Invoke(AudioClips.Failed);
            }
        }
        else if(secondCleared && submittedList.Count == 7)
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
