using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{


    Rigidbody2D playerBody;
    [SerializeField] float maxRunSpeed = 8f;
    [SerializeField] float acceleration = 10f;
    [SerializeField] float deceleration = 20f;
    [SerializeField] float velPower = 0.7f;

    SpriteRenderer playerSprite;
    Animator playerAnimator;

    BoxCollider2D groundCheck;
    public LayerMask groundMask;

    public bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponentInChildren<Rigidbody2D>();
        playerSprite = playerBody.gameObject.GetComponent<SpriteRenderer>();
        playerAnimator = playerBody.gameObject.GetComponent<Animator>();
        groundCheck = GetComponentInChildren<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        int moveInput = 0;

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

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, 8);
        }
        if (Input.GetKeyUp(KeyCode.Space) && !grounded && playerBody.velocity.y > 0)
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, playerBody.velocity.y / 2);
        }

        float targetSpeed = moveInput * maxRunSpeed;
        float speedDif = targetSpeed - playerBody.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : deceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);

        playerBody.AddForce(movement * Vector2.right);

        playerAnimator.SetFloat("Speed", Mathf.Abs(playerBody.velocity.x));

        if (playerBody.velocity.y > 0 && !grounded)
        {
            playerAnimator.SetBool("jumping", true);
            playerAnimator.SetBool("falling", false);
        }
        else if (playerBody.velocity.y < 0 && !grounded)
        {
            playerAnimator.SetBool("falling", true);
            playerAnimator.SetBool("jumping", false);
        }
        else if (grounded)
        {
            playerAnimator.SetBool("falling", false);
            playerAnimator.SetBool("jumping", false);
        }
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    void CheckGround()
    {
        grounded = (Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0);
    }
}
