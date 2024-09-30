using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableCharacter : MonoBehaviour//, IDamageable
{

    public Player player;
    public bool isThePlayer;
    Animator animator;
    Rigidbody2D rb;
    Collider2D col;
    public int _health;
    public bool _targetable = true;
    public bool _invincible = false;

    // Start is called before the first frame update
    void Start()
    {
        _health = player.getPlayerHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void isPlayer(bool playableCharacter)
    {
        this.isThePlayer = playableCharacter;
    }

    public int Health { 
        get {
            this.Health = player.getPlayerHealth();
            return 0; 
        } 
        set
        {
            if (isThePlayer)
            {
                if (value < player.getPlayerHealth())
                {
                    animator.SetTrigger("hit");
                }
            }

        }
    }
    public void OnHit(int damage, Vector2 knockback)
    {

    }
}
