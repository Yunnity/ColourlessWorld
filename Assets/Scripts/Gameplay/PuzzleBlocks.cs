using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBlocks : MonoBehaviour
{
    private void Start()
    {
        EventManager.AddDestroyPuzzleListener(DestroyBlock);
    }

    void DestroyBlock()
    {
        Destroy(gameObject);
    }
}
