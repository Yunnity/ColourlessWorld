using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleHint : MonoBehaviour
{
    [SerializeField]
    GameObject puzzleHintPrefab;
    bool hintOnScreen = false;
    BoxCollider2D bc2d;
    Vector2 lowerLeft;
    Vector2 upperRight;

    //void Start()
    //{
    //    bc2d = gameObject.GetComponent<BoxCollider2D>();
    //    lowerLeft = new Vector2(gameObject.transform.position.x - bc2d.size.x / 2, gameObject.transform.position.y - bc2d.size.y / 2);
    //    upperRight = new Vector2(gameObject.transform.position.x + bc2d.size.x / 2, gameObject.transform.position.y + bc2d.size.y / 2);
    //}

    //void Update()
    //{
    //    if(Physics2D.OverlapArea(lowerLeft, upperRight) != null && !hintOnScreen)
    //    {
    //        Instantiate(puzzleHintPrefab, transform.position, Quaternion.identity);
    //        hintOnScreen = true;
    //    }
    //    else if(Physics2D.OverlapArea(lowerLeft, upperRight) == null)
    //    {
    //        Destroy(GameObject.FindGameObjectWithTag("PuzzleHint"));
    //        hintOnScreen = false;
    //    }
    //}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !hintOnScreen)
        {
            Instantiate(puzzleHintPrefab, transform.position, Quaternion.identity);
            hintOnScreen = true;
        }
        else if(hintOnScreen)
        {
            Destroy(GameObject.FindGameObjectWithTag("PuzzleHint"));
            hintOnScreen = false;
        }
    }
}
