using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using System;

public class OneOne : General
{
    protected override void Start()
    {
        base.Start();
        EventManager.AddColourTouchedListener(AddColourToList);
    }

    void AddColourToList(string colour)
    {
        submittedList.Add(colour);
        if(submittedList.Count == 5)
        {
            if (submittedList.SequenceEqual(answerList))
            {
                destroyPuzzleEvent.Invoke();
                generalSFX.Invoke(AudioClips.Cleared);
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
