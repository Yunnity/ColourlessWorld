using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EscapeRope : MonoBehaviour
{ 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(GameObject.FindGameObjectWithTag("TempHint"));
            GameObject[] tempArr = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
            foreach(GameObject tile in tempArr)
            {
                if(tile.layer == LayerMask.NameToLayer("PaintTile2"))
                {
                    tile.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("blankPaintTile");
                }
            }
        }
    }
}
