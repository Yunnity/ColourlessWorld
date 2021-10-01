using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PuzzlePaintTiles : MonoBehaviour
{
    ColourTouchedEvent colourTouchedEvent;
    BlockSelectedEvent blockSelectedEvent;
    int puzzleTilesLayer;
    private void Start()
    {
        puzzleTilesLayer = LayerMask.NameToLayer("PaintTile0");
        colourTouchedEvent = new ColourTouchedEvent();
        blockSelectedEvent = new BlockSelectedEvent();
        EventManager.AddColourTouchedInvoker(this);
        EventManager.AddBlockSelectedInvoker(this);
        EventManager.AddLayerIncrementListener(NextPuzzle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && gameObject.layer == puzzleTilesLayer)
        {
            colourTouchedEvent.Invoke(gameObject.tag);
            blockSelectedEvent.Invoke(AudioClips.BlockSelect);
        }
    }

    public void AddColourTouchedListener(UnityAction<string> listener)
    {
        colourTouchedEvent.AddListener(listener);
    }

    public void AddBlockSelectedListener(UnityAction<AudioClips> listener)
    {
        blockSelectedEvent.AddListener(listener);
    }

    void NextPuzzle()
    {
        puzzleTilesLayer++;
    }
}
