using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLockedNotice : MonoBehaviour
{
    Stopwatch lifeSpanTimer;

    // Start is called before the first frame update
    void Start()
    {
        lifeSpanTimer = gameObject.AddComponent<Stopwatch>();
        lifeSpanTimer.Duration = 2;
        lifeSpanTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeSpanTimer.IsFinished)
        {
            Destroy(gameObject);
        }
    }
}
