using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class Player : MonoBehaviour
{
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField]
    GameObject prefabBullet;

    protected float moveSpeed;
    protected float jumpConstant;
    protected float attackCd;
    protected bool gamePaused = false;

    Rigidbody2D rb2d;
    Timer airborneTimer;
    Timer jumpTimer;
    Timer momentumTimer;
    BoxCollider2D bc2d;
    Animator anim;
    float halfWidth;
    bool facingRight = true;
    bool groundedOnce = false;
    float timeAtFire = 0;
    CharacterDeathEvent characterDeathEvent;
    PlayerSFX playerSFX;
    bool doubleJumped = false;

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        bc2d = gameObject.GetComponent<BoxCollider2D>();
        jumpTimer = gameObject.AddComponent<Timer>();
        airborneTimer = gameObject.AddComponent<Timer>();
        momentumTimer = gameObject.AddComponent<Timer>();
        halfWidth = bc2d.size.x;
        characterDeathEvent = new CharacterDeathEvent();
        playerSFX = new PlayerSFX();
        EventManager.AddPlayerDeathInvoker(this);
        EventManager.AddPlayerSFXInvoker(this);
        EventManager.AddGamePausedListener(GamePaused);
        EventManager.AddGameResumedListener(GameResumed);
    }

    private void Update()
    {
        float horizMove = Input.GetAxis("Horizontal");
        if (Input.GetAxis("Horizontal") != 0)
        {
            rb2d.velocity = new Vector2(horizMove * moveSpeed, rb2d.velocity.y);
            momentumTimer.Stop();
        }
        if(Input.GetAxis("Horizontal") == 0)
        {
            momentumTimer.Run();
        }
        if(momentumTimer.ElapsedSeconds >= 1.5f)
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        if (Mathf.Abs(horizMove) > 0.05)
        {
            anim.SetBool("charRunning", true);
        }
        else
        {
            anim.SetBool("charRunning", false);
        }
        if(horizMove > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }
        else if(horizMove < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
        if(!IsGrounded())
        {
            StartAirTime();
        }
        if(Input.GetButtonDown("Jump") && !IsGrounded() && airborneTimer.ElapsedSeconds <= 0.2f && rb2d.velocity.y <= 0
            && !jumpTimer.Running && groundedOnce)
        {
            Jump();
        }
        if (Input.GetMouseButtonDown(0) && timeAtFire < Time.time && !gamePaused &&
            gameObject.GetComponent<SpecialChar>().CharacterType == PlayerType.Melancholic)
        {
            ShootBullet();
            timeAtFire = Time.time + attackCd;
            playerSFX.Invoke(AudioClips.Shoot);
        }
        anim.SetBool("charGrounded", IsGrounded());
        if(!IsGrounded() && gameObject.GetComponent<SpecialChar>().CharacterType == PlayerType.Hectic && !doubleJumped)
        {
            Jump();
            doubleJumped = true;
        }
    }

    void Jump()
    {
        Vector2 newSpeed = new Vector2(rb2d.velocity.x, jumpConstant);
        rb2d.velocity = newSpeed;
        jumpTimer.Run();
        PlayerType playerType = gameObject.GetComponent<SpecialChar>().CharacterType;
        //if(playerType == PlayerType.Standard)
        //{
        //    playerSFX.Invoke(AudioClips.StandardJump);
        //}
        //else if(playerType == PlayerType.Melancholic)
        //{
        //    playerSFX.Invoke(AudioClips.MelancholicJump);
        //}
        playerSFX.Invoke(AudioClips.StandardJump);
    }

    bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0, Vector2.down, 0.2f, groundLayer);
        if(raycastHit)
        {
            airborneTimer.Stop();
            jumpTimer.Stop();
            doubleJumped = false;
            return groundedOnce = true;
        }
        return false;
    }

    void StartAirTime()
    {
        if(!airborneTimer.Running)
        {
            airborneTimer.Run();
        }
    }

    void ShootBullet()
    {
        float angle;
        Vector3 spawnLocation = gameObject.transform.position;
        if(facingRight)
        {
            spawnLocation.x += halfWidth;
            angle = 0;
        }
        else
        {
            spawnLocation.x -= halfWidth;
            angle = 180;
        }
        Instantiate(prefabBullet, spawnLocation, Quaternion.Euler(0, 0, angle));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            characterDeathEvent.Invoke();
            playerSFX.Invoke(AudioClips.StandardDeath);
        }
        else if (collision.gameObject.CompareTag("Lava"))
        {
            if(gameObject.GetComponent<SpecialChar>().CharacterType != PlayerType.Melancholic)
            {
                Destroy(gameObject);
                playerSFX.Invoke(AudioClips.Toasted);
                characterDeathEvent.Invoke();
            }
        }
        else if(collision.gameObject.CompareTag("Hydro"))
        {
            if(gameObject.GetComponent<SpecialChar>().CharacterType != PlayerType.Arsonist)
            {
                Destroy(gameObject);
                playerSFX.Invoke(AudioClips.Doused);
                characterDeathEvent.Invoke();
            }
        }
        else if(collision.gameObject.tag == "Escape")
        {
            Destroy(gameObject);
            characterDeathEvent.Invoke();
            playerSFX.Invoke(AudioClips.EscapeRope);
        }
        else if(collision.gameObject.CompareTag("DeathZone"))
        {
            Destroy(gameObject);
            characterDeathEvent.Invoke();
            playerSFX.Invoke(AudioClips.OutOfBounds);
        }
    }

    public void AddPlayerDeathListener(UnityAction listener)
    {
        characterDeathEvent.AddListener(listener);
    }

    public void AddPlayerSFXListener(UnityAction<AudioClips> listener)
    {
        playerSFX.AddListener(listener);
    }

    void GamePaused()
    {
        gamePaused = true;
        playerSFX.Invoke(AudioClips.GamePaused);
    }

    void GameResumed()
    {
        gamePaused = false;
    }
}
