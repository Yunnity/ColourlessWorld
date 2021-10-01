using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField]
    Sprite enemyRight;
    [SerializeField]
    Sprite enemyLeft;

    bool facingRight;
    Rigidbody2D rb2d;
    BoxCollider2D bc2d;
    SpriteRenderer currSprite;
    float edgeDistance;

    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        bc2d = gameObject.GetComponent<BoxCollider2D>();
        currSprite = gameObject.GetComponent<SpriteRenderer>();
        edgeDistance = bc2d.size.x / 2;
        if (currSprite.sprite.name == "enemySpriteLeft")
        {
            facingRight = false;
        }
        else
        {
            facingRight = true;
        }
    }

    private void Update()
    {
        if (facingRight)
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
        }
        CheckTurn();
    }

    void CheckTurn()
    {
        RaycastHit2D raycastHitVert = Physics2D.BoxCast(bc2d.bounds.center + new Vector3(edgeDistance + 0.3f, 0, 0),
                bc2d.bounds.size, 0, Vector2.down, 0.3f, groundLayer);
        //RaycastHit2D raycastHitHoriz = Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0, Vector2.right, 0.3f, groundLayer);
        if (!facingRight)
        {
            raycastHitVert = Physics2D.BoxCast(bc2d.bounds.center - new Vector3(edgeDistance + 0.3f, 0, 0),
                bc2d.bounds.size, 0, Vector2.down, 0.3f, groundLayer);
            //raycastHitHoriz = Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0, Vector2.left, 0.3f, groundLayer);
        }

        if (!raycastHitVert)
        {
            if (facingRight)
            {
                facingRight = false;
                currSprite.sprite = enemyLeft;
            }
            else
            {
                facingRight = true;
                currSprite.sprite = enemyRight;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            if(facingRight)
            {
                facingRight = false;
                currSprite.sprite = enemyLeft;
            }
            else
            {
                facingRight = true;
                currSprite.sprite = enemyRight;
            }
        }
    }
}
