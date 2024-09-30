using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region Variables
    public int playerMaxHP;
    public int playerHP;
    public int playerLives;
    Animator playerAnimation;
    Rigidbody2D playerBody;
    SpriteRenderer playerSprite;
    AnimationTriggers jumpTrig;
    int moveInput = 0;
    BoxCollider2D groundCheck;
    public LayerMask groundMask;
    bool grounded;
    GameManager gameManager;

    #endregion
    #region Serialized Field Variables
    [SerializeField] float maxRunSpeed = 8.0f;
    [SerializeField] float acceleration = 10f;
    [SerializeField] float deceleration = 20f;
    [SerializeField] float velPower = 0.7f;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {        
        playerMove();
    }
   
    #region Methods
    private void playerMove()
    {
        moveInput = 0;
        playerDirectionAnimation();
        RunAnimation();
        JumpAnimation();
    }
   
    private void Init()
    {
        playerBody = GetComponentInChildren<Rigidbody2D>();
        playerSprite = playerBody.gameObject.GetComponent<SpriteRenderer>();
        playerAnimation = playerBody.gameObject.GetComponent<Animator>();
        groundCheck = GetComponentInChildren<BoxCollider2D>();
        gameManager = GameManager.instance;

        //enemy and player ignore collision
        Physics2D.IgnoreLayerCollision(8, 7);
        Physics2D.IgnoreLayerCollision(8, 8);//so if multiplayer, users can walk through one another.

        //initial player state
        playerMaxHP = 3; //number of containers
        playerHP = 6;    //current health, each container is 2 HP (empty, half, or full)
        playerLives = 3;
    }
 
    private void playerDirectionAnimation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1;
            playerSprite.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1;
            playerSprite.flipX = false;
        }
    }
   
    private void RunAnimation()
    {
        float targetSpeed = moveInput * maxRunSpeed;
        float speedDif = targetSpeed - playerBody.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : deceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);

        playerBody.AddForce(movement * Vector2.right);
        float vel = Mathf.Abs(playerBody.velocity.x);
        if (vel > 0.8) playerAnimation.SetFloat("speed", 1);
        else playerAnimation.SetFloat("speed", 0);
    }
  
    private void JumpAnimation()
    {
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, 8);
        }
        if (Input.GetKeyUp(KeyCode.Space) && !grounded && playerBody.velocity.y > 0)
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, playerBody.velocity.y / 2);
        }

        if (playerBody.velocity.y > 0 && !grounded)
        {
            playerAnimation.SetBool("jumping", true);
            playerAnimation.SetBool("falling", false);
        }
        else if (playerBody.velocity.y <= 1 && !grounded)
        {
            playerAnimation.SetBool("falling", true);
            playerAnimation.SetBool("jumping", false);
        }
        else if (grounded)
        {
            playerAnimation.SetBool("falling", false);
            playerAnimation.SetBool("jumping", false);
        }
    }
  
    private void FixedUpdate()
    {
        CheckGround();
    }
  
    private void CheckGround()
    {
        grounded = (Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0);
    }
    
    public void IncreaseMaxHealth()
    {
        playerMaxHP++;
        playerHP += 2;
    }

    public void DecreaseMaxHealth()
    {
        playerHP -= 2;
        playerMaxHP--;
    }

    public void IncreaseHealth()
    {
        playerHP += 2;
        if(playerHP > (2 * playerMaxHP)) playerHP = (2 * playerMaxHP);
    }

    public void DeacreaseHealth(int dmg)
    {
        playerHP -= dmg;
        if(playerHP <0) playerHP = 0;
        if (playerHP == 0) playerDeath();
    }

    public void playerDeath()
    {
        //set animation and reduce 
        playerLives--;
        //if (playerLives == 0) gameManager.GAMEOVER();
    }

    public int getPlayerMaxHealth() { return playerMaxHP; }
   
    public int getPlayerHealth() { return playerHP; }
    #endregion

    #region Collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }

    #endregion
}
