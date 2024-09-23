using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Variables
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

    //objects
    public TextMeshProUGUI livetrack;
    
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        updateLives();
    }

    private void updateLives()
    {
        livetrack.text = "x " + playerLives.ToString();
    }

    private void Init()
    {
        if(instance != null && this != instance) Destroy(this);
        else instance = this;

    }
}
