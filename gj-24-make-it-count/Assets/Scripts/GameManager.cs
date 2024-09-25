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
    int levTime;
    int score;
    int sysTime;

    //other variable
    //InGameTimer levelTimer;

    //Temp variables DELETE when done
    int frameCounter = 0;

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
    public TextMeshProUGUI leveltrack;
    public TextMeshProUGUI scoreTrack;
    
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private void FixedUpdate()
    {
        updateHUD();
    }
    
    private void updateLives()
    {
        livetrack.text = "x " + playerLives.ToString();
    }
  
    private void updateLevel()
    {
        leveltrack.text = "Level: " + levelCounter.ToString();
    }

    private void updateScore()
    {
        scoreTrack.text = "Score: " + score.ToString();
    }
  
    private void Init()
    {
        if(instance != null && this != instance) Destroy(this);
        else instance = this;
        playerLives = 5;
        levelCounter = 1;
        score = 0;
        InGameTimer.timer.beginTimer();
    }

    private void updateHUD()
    {
        //temp for testing//
        changeTestValues();
        ////////////////////
        updateLevel();
        updateLives();
        updateScore();
    }

    private void changeTestValues()
    {
        if(frameCounter++ == 45)
        {
            frameCounter = 0;
            score += (score + 2)/2;
            playerLives = score / 2;
            levelCounter = playerLives/2;

        }
    }
}
