using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OneFive : General
{
    protected override void Start()
    {
        base.Start();
        answerList.Add("Green");
        answerList.Add("Green");
        answerList.Add("Black");
        answerList.Add("White");
        EventManager.AddColourTouchedListener(AddColourToList);
    }

    void AddColourToList(string colour)
    {
        submittedList.Add(colour);
        if(!firstCleared && submittedList.Count == 4)
        {
            if(answerList.SequenceEqual(submittedList))
            {
                firstCleared = true;
                destroyPuzzleEvent.Invoke();
                generalSFX.Invoke(AudioClips.Cleared);
                incrementLayerEvent.Invoke();
                answerList.Clear();
                //answerList.Add();
            }
            else
            {
                generalSFX.Invoke(AudioClips.Failed);
            }
            submittedList.Clear();
        }
    }
}
