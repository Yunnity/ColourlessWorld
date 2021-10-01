using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class OneFour : General
{
    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        answerList.Add("White");
        answerList.Add("Blue");
        answerList.Add("Black");
        answerList.Add("Red");
        EventManager.AddColourTouchedListener(AddColourToList);
    }

    void AddColourToList(string colour)
    {
        submittedList.Add(colour);
        if(!firstCleared && submittedList.Count == 4)
        {
            if (submittedList.SequenceEqual(answerList))
            {
                answerList.Clear();
                firstCleared = true;
                answerList.Add("Orange");
                answerList.Add("Gray");
                answerList.Add("Yellow");
                generalSFX.Invoke(AudioClips.Cleared);
                incrementLayerEvent.Invoke();
                destroyPuzzleEvent.Invoke();
                GameObject.FindGameObjectWithTag("Trial2").AddComponent<PuzzleBlocks>();
            }
            else
            {
                generalSFX.Invoke(AudioClips.Failed);
            }
            submittedList.Clear();
        }
        else if(firstCleared && !secondCleared && submittedList.Count == 3)
        {
            if(submittedList.SequenceEqual(answerList))
            {
                answerList.Clear();
                secondCleared = true;
                incrementLayerEvent.Invoke();
                destroyPuzzleEvent.Invoke();
                generalSFX.Invoke(AudioClips.Cleared);
                answerList.Add("Black");
                answerList.Add("Orange");
                answerList.Add("Blue");
                GameObject.FindGameObjectWithTag("Puzzle").AddComponent<PuzzleBlocks>();
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
                destroyPuzzleEvent.Invoke();
                incrementLayerEvent.Invoke();
                generalSFX.Invoke(AudioClips.Cleared);
            }
            else
            {
                submittedList.Clear();
                generalSFX.Invoke(AudioClips.Failed);
            }
        }
    }
}
