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
    private int miliCount = 0;
    private int secCount = 0;
    private int minCount = 0;
    private string mil;
    private string sec;
    private string min;

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
    public TextMeshProUGUI levelTime;
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
        updateHUD();
    }

    private void updateLives()
    {
        livetrack.text = "x " + playerLives.ToString();
    }
  
    //Should only be checked once per level (change later)
    private void updateLevel()
    {
        leveltrack.text = "Level: " + levelCounter.ToString();
    }
    //improve timer later, just for display purposed right now.!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    private void updateTimer()
    {

        sysTime = (int)(Time.time * 10);
        //miliCount 
        if (sysTime % 10 == 0)
        {
            mil = "0";
            secCount++;
        }
        if (secCount == 60)
        {
            secCount = 0;
            minCount++;
        }
        mil = miliCount.ToString();
        sec = (secCount < 10) ? "0" + secCount.ToString() : secCount.ToString();
        min = (minCount < 10) ? "0" + minCount.ToString() : minCount.ToString();

        levelTime.text = "Time: " + min + ":" + sec + ":" + mil;
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
        levTime = 0;
        score = 0;

    }

    private void updateHUD()
    {
        //temp for testing//
        changeTestValues();
        ////////////////////
        updateLevel();
        updateLives();
        updateTimer();
        updateScore();
    }

    private void changeTestValues()
    {
        if(frameCounter++ == 45)
        {
            frameCounter = 0;
            levTime++;
            score = levTime/2;
            playerLives = score / 2;
            levelCounter = playerLives/2;

            //updateTimer();
        }
        //killCounter;
    }
}
