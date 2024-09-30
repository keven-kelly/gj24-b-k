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
    public Player player;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;
    public GameObject heart5;
    public GameObject heart6;
    public GameObject heart7;
    public GameObject heart8;
    public GameObject heart9;
    public GameObject heart10;
    public GameObject heart11;
    public GameObject heart12;
    public SpriteRenderer h1SpriteRenderer;
    public SpriteRenderer h2SpriteRenderer;
    public SpriteRenderer h3SpriteRenderer;
    public SpriteRenderer h4SpriteRenderer;
    public SpriteRenderer h5SpriteRenderer;
    public SpriteRenderer h6SpriteRenderer;
    public SpriteRenderer h7SpriteRenderer;
    public SpriteRenderer h8SpriteRenderer;
    public SpriteRenderer h9SpriteRenderer;
    public SpriteRenderer h10SpriteRenderer;
    public SpriteRenderer h11SpriteRenderer;
    public SpriteRenderer h12SpriteRenderer;
    public Sprite emptyHeart;
    public Sprite halfHeart;
    public Sprite fullHeart;
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
        updateMaxHP();
        updateHP();
    }

    private void updateMaxHP()
    {
        int maxHP = player.getPlayerMaxHealth();
        heart1.SetActive(false);
        heart2.SetActive(false);
        heart3.SetActive(false);
        heart4.SetActive(false);
        heart5.SetActive(false);
        heart6.SetActive(false);
        heart7.SetActive(false);
        heart8.SetActive(false);
        heart9.SetActive(false);
        heart10.SetActive(false);
        heart11.SetActive(false);
        heart12.SetActive(false);
        switch (maxHP)
        {
            case 4:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                heart4.SetActive(true);
                break;
            case 5:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                heart4.SetActive(true);
                heart5.SetActive(true);
                break;
            case 6:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                heart4.SetActive(true);
                heart5.SetActive(true);
                heart6.SetActive(true);
                break;
            case 7:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                heart4.SetActive(true);
                heart5.SetActive(true);
                heart6.SetActive(true);
                heart7.SetActive(true);
                break;
            case 8:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                heart4.SetActive(true);
                heart5.SetActive(true);
                heart6.SetActive(true);
                heart7.SetActive(true);
                heart8.SetActive(true);
                break;
            case 9:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                heart4.SetActive(true);
                heart5.SetActive(true);
                heart6.SetActive(true);
                heart7.SetActive(true);
                heart8.SetActive(true);
                heart9.SetActive(true);
                break;
            case 10:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                heart4.SetActive(true);
                heart5.SetActive(true);
                heart6.SetActive(true);
                heart7.SetActive(true);
                heart8.SetActive(true);
                heart9.SetActive(true);
                heart10.SetActive(true);
                break;
            case 11:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                heart4.SetActive(true);
                heart5.SetActive(true);
                heart6.SetActive(true);
                heart7.SetActive(true);
                heart8.SetActive(true);
                heart9.SetActive(true);
                heart10.SetActive(true);
                heart11.SetActive(true);
                break;
            case 12:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                heart4.SetActive(true);
                heart5.SetActive(true);
                heart6.SetActive(true);
                heart7.SetActive(true);
                heart8.SetActive(true);
                heart9.SetActive(true);
                heart10.SetActive(true);
                heart11.SetActive(true);
                heart12.SetActive(true);
                break;
            default: // 3 hearts
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                break;

        }
    }

    private void updateHP()
    {
        h1SpriteRenderer.sprite = emptyHeart;
        h2SpriteRenderer.sprite = emptyHeart;
        h3SpriteRenderer.sprite = emptyHeart;
        h4SpriteRenderer.sprite = emptyHeart;
        h5SpriteRenderer.sprite = emptyHeart;
        h6SpriteRenderer.sprite = emptyHeart;
        h7SpriteRenderer.sprite = emptyHeart;
        h8SpriteRenderer.sprite = emptyHeart;
        h9SpriteRenderer.sprite = emptyHeart;
        h10SpriteRenderer.sprite = emptyHeart;
        h11SpriteRenderer.sprite = emptyHeart;
        h12SpriteRenderer.sprite = emptyHeart;
        int hp = player.getPlayerHealth();
        switch (hp)
        {
            case 1:
                h1SpriteRenderer.sprite = halfHeart;
                break;
            case 2:
                h1SpriteRenderer.sprite = fullHeart;
                break;
            case 3:
                h1SpriteRenderer.sprite = fullHeart;
                h2SpriteRenderer.sprite = halfHeart;
                break;
            case 4:
                h1SpriteRenderer.sprite = fullHeart;
                h2SpriteRenderer.sprite = fullHeart;
                break;
            case 5:
                h1SpriteRenderer.sprite = fullHeart;
                h2SpriteRenderer.sprite = fullHeart;
                h3SpriteRenderer.sprite = halfHeart;
                break;
            case 6:
                h1SpriteRenderer.sprite = fullHeart;
                h2SpriteRenderer.sprite = fullHeart;
                h3SpriteRenderer.sprite = fullHeart;
                break;
            case 7:
                h1SpriteRenderer.sprite = fullHeart;
                h2SpriteRenderer.sprite = fullHeart;
                h3SpriteRenderer.sprite = fullHeart;
                h4SpriteRenderer.sprite = halfHeart;
                break;
            case 8:
                h1SpriteRenderer.sprite = fullHeart;
                h2SpriteRenderer.sprite = fullHeart;
                h3SpriteRenderer.sprite = fullHeart;
                h4SpriteRenderer.sprite = fullHeart;
                break;
            case 9:
                h1SpriteRenderer.sprite = fullHeart;
                h2SpriteRenderer.sprite = fullHeart;
                h3SpriteRenderer.sprite = fullHeart;
                h4SpriteRenderer.sprite = fullHeart;
                h5SpriteRenderer.sprite = halfHeart;
                break;
            case 10:
                h1SpriteRenderer.sprite = fullHeart;
                h2SpriteRenderer.sprite = fullHeart;
                h3SpriteRenderer.sprite = fullHeart;
                h4SpriteRenderer.sprite = fullHeart;
                h5SpriteRenderer.sprite = fullHeart;
                break; 
            case 11:
                h1SpriteRenderer.sprite = fullHeart;
                h2SpriteRenderer.sprite = fullHeart;
                h3SpriteRenderer.sprite = fullHeart;
                h4SpriteRenderer.sprite = fullHeart;
                h5SpriteRenderer.sprite = fullHeart;
                h6SpriteRenderer.sprite = halfHeart;
                break;
            case 12:
                h1SpriteRenderer.sprite = fullHeart;
                h2SpriteRenderer.sprite = fullHeart;
                h3SpriteRenderer.sprite = fullHeart;
                h4SpriteRenderer.sprite = fullHeart;
                h5SpriteRenderer.sprite = fullHeart;
                h6SpriteRenderer.sprite = fullHeart;
                break;
            case 13:
                h1SpriteRenderer.sprite = fullHeart;
                h2SpriteRenderer.sprite = fullHeart;
                h3SpriteRenderer.sprite = fullHeart;
                h4SpriteRenderer.sprite = fullHeart;
                h5SpriteRenderer.sprite = fullHeart;
                h6SpriteRenderer.sprite = fullHeart;
                h7SpriteRenderer.sprite = halfHeart;
                break;
            case 14:
                h1SpriteRenderer.sprite = fullHeart;
                h2SpriteRenderer.sprite = fullHeart;
                h3SpriteRenderer.sprite = fullHeart;
                h4SpriteRenderer.sprite = fullHeart;
                h5SpriteRenderer.sprite = fullHeart;
                h6SpriteRenderer.sprite = fullHeart;
                h7SpriteRenderer.sprite = fullHeart;
                break;
            case 15:
                h1SpriteRenderer.sprite = fullHeart;
                h2SpriteRenderer.sprite = fullHeart;
                h3SpriteRenderer.sprite = fullHeart;
                h4SpriteRenderer.sprite = fullHeart;
                h5SpriteRenderer.sprite = fullHeart;
                h6SpriteRenderer.sprite = fullHeart;
                h7SpriteRenderer.sprite = fullHeart;
                h8SpriteRenderer.sprite = halfHeart;
                break;
            case 16:
                h1SpriteRenderer.sprite = fullHeart;
                h2SpriteRenderer.sprite = fullHeart;
                h3SpriteRenderer.sprite = fullHeart;
                h4SpriteRenderer.sprite = fullHeart;
                h5SpriteRenderer.sprite = fullHeart;
                h6SpriteRenderer.sprite = fullHeart;
                h7SpriteRenderer.sprite = fullHeart;
                h8SpriteRenderer.sprite = fullHeart;
                break;
            case 17:
                h1SpriteRenderer.sprite = fullHeart;
                h2SpriteRenderer.sprite = fullHeart;
                h3SpriteRenderer.sprite = fullHeart;
                h4SpriteRenderer.sprite = fullHeart;
                h5SpriteRenderer.sprite = fullHeart;
                h6SpriteRenderer.sprite = fullHeart;
                h7SpriteRenderer.sprite = fullHeart;
                h8SpriteRenderer.sprite = fullHeart;
                h9SpriteRenderer.sprite = halfHeart;
                break;
            case 18:
                h1SpriteRenderer.sprite = fullHeart;
                h2SpriteRenderer.sprite = fullHeart;
                h3SpriteRenderer.sprite = fullHeart;
                h4SpriteRenderer.sprite = fullHeart;
                h5SpriteRenderer.sprite = fullHeart;
                h6SpriteRenderer.sprite = fullHeart;
                h7SpriteRenderer.sprite = fullHeart;
                h8SpriteRenderer.sprite = fullHeart;
                h9SpriteRenderer.sprite = fullHeart;
                break;
            case 19:
                h1SpriteRenderer.sprite = fullHeart;
                h2SpriteRenderer.sprite = fullHeart;
                h3SpriteRenderer.sprite = fullHeart;
                h4SpriteRenderer.sprite = fullHeart;
                h5SpriteRenderer.sprite = fullHeart;
                h6SpriteRenderer.sprite = fullHeart;
                h7SpriteRenderer.sprite = fullHeart;
                h8SpriteRenderer.sprite = fullHeart;
                h9SpriteRenderer.sprite = fullHeart;
                h10SpriteRenderer.sprite = halfHeart;
                break;
            case 20:
                h1SpriteRenderer.sprite = fullHeart;
                h2SpriteRenderer.sprite = fullHeart;
                h3SpriteRenderer.sprite = fullHeart;
                h4SpriteRenderer.sprite = fullHeart;
                h5SpriteRenderer.sprite = fullHeart;
                h6SpriteRenderer.sprite = fullHeart;
                h7SpriteRenderer.sprite = fullHeart;
                h8SpriteRenderer.sprite = fullHeart;
                h9SpriteRenderer.sprite = fullHeart;
                h10SpriteRenderer.sprite = fullHeart;
                break;
            case 21:
                h1SpriteRenderer.sprite = fullHeart;
                h2SpriteRenderer.sprite = fullHeart;
                h3SpriteRenderer.sprite = fullHeart;
                h4SpriteRenderer.sprite = fullHeart;
                h5SpriteRenderer.sprite = fullHeart;
                h6SpriteRenderer.sprite = fullHeart;
                h7SpriteRenderer.sprite = fullHeart;
                h8SpriteRenderer.sprite = fullHeart;
                h9SpriteRenderer.sprite = fullHeart;
                h10SpriteRenderer.sprite = fullHeart;
                h11SpriteRenderer.sprite = halfHeart;
                break;
            case 22:
                h1SpriteRenderer.sprite = fullHeart;
                h2SpriteRenderer.sprite = fullHeart;
                h3SpriteRenderer.sprite = fullHeart;
                h4SpriteRenderer.sprite = fullHeart;
                h5SpriteRenderer.sprite = fullHeart;
                h6SpriteRenderer.sprite = fullHeart;
                h7SpriteRenderer.sprite = fullHeart;
                h8SpriteRenderer.sprite = fullHeart;
                h9SpriteRenderer.sprite = fullHeart;
                h10SpriteRenderer.sprite = fullHeart;
                h11SpriteRenderer.sprite = fullHeart;
                break;
            case 23:
                h1SpriteRenderer.sprite = fullHeart;
                h2SpriteRenderer.sprite = fullHeart;
                h3SpriteRenderer.sprite = fullHeart;
                h4SpriteRenderer.sprite = fullHeart;
                h5SpriteRenderer.sprite = fullHeart;
                h6SpriteRenderer.sprite = fullHeart;
                h7SpriteRenderer.sprite = fullHeart;
                h8SpriteRenderer.sprite = fullHeart;
                h9SpriteRenderer.sprite = fullHeart;
                h10SpriteRenderer.sprite = fullHeart;
                h11SpriteRenderer.sprite = fullHeart;
                h12SpriteRenderer.sprite = halfHeart;
                break;
            case 24:
                h1SpriteRenderer.sprite = fullHeart;
                h2SpriteRenderer.sprite = fullHeart;
                h3SpriteRenderer.sprite = fullHeart;
                h4SpriteRenderer.sprite = fullHeart;
                h5SpriteRenderer.sprite = fullHeart;
                h6SpriteRenderer.sprite = fullHeart;
                h7SpriteRenderer.sprite = fullHeart;
                h8SpriteRenderer.sprite = fullHeart;
                h9SpriteRenderer.sprite = fullHeart;
                h10SpriteRenderer.sprite = fullHeart;
                h11SpriteRenderer.sprite = fullHeart;
                h12SpriteRenderer.sprite = fullHeart;
                break;
            default:
                break;
        }
    }

    public void GAMEOVER()
    {

    }

    private void changeTestValues()
    {
        if(frameCounter++ == 45)
        {
            frameCounter = 0;
            score += (score + 2)/2;
            //playerLives = score / 2;
            //levelCounter = playerLives/2;
            player.DeacreaseHealth(1);
            if(player.getPlayerHealth() == 0)
            {
                player.IncreaseMaxHealth();
                player.playerHP = player.playerMaxHP * 2;
            }
            if(player.getPlayerMaxHealth() == 12) { player.playerMaxHP = 3; }

        }
    }
}