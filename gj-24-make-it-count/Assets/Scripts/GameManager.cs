using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int playerLives;
    int playerMaxHP;
    int levelCounter;
    int bonusMax;
    int debuffMax;
    int killCounter;

    //should be in player
    int playerHP;
    bool invinceBuff;
    int debuffSpeed;
    int debuffHealth;
    int debuffAttack;
    int debuffJump;
    int attackBonus;
    int movementBonus;
    int jumpBonus;


    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && this != instance)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
