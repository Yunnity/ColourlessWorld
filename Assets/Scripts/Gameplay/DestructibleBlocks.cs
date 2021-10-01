using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Events;

public class DestructibleBlocks : MonoBehaviour
{
    //[SerializeField]
    //GameObject prefabExplosion;

    Tilemap destructibleTiles;
    BlockBreakingEvent blockBreakingEvent;

    // Start is called before the first frame update
    void Start()
    {
        destructibleTiles = GetComponent<Tilemap>();
        blockBreakingEvent = new BlockBreakingEvent();
        EventManager.AddBrokenBlockInvoker(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Vector3 hitPosition = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts)
            {
                if (collision.transform.position.x > transform.position.x)
                {
                    hitPosition.x = hit.point.x + 0.1f;
                    hitPosition.y = hit.point.y + 0.1f;
                }
                else
                {
                    hitPosition.x = hit.point.x - 0.1f;
                    hitPosition.y = hit.point.y - 0.1f;
                }
                destructibleTiles.SetTile(destructibleTiles.WorldToCell(hitPosition), null);
                blockBreakingEvent.Invoke(AudioClips.BreakBlock);
            }
        }
    }

    public void AddBrokenBlockListener(UnityAction<AudioClips> listener)
    {
        blockBreakingEvent.AddListener(listener);
    }
}
