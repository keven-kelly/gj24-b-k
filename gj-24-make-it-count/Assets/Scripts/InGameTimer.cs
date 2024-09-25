using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameTimer : MonoBehaviour
{
    #region Variable
    //public
    public Text LevelTimer;
    public static InGameTimer timer;
    //private
    private TimeSpan playTime;
    private bool inGame;
    private float timeCount;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        LevelTimer.text = "Time: ";
        inGame = false;
    }

    private void Awake()
    {
        timer = this;
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    private IEnumerator TimerUpdate()
    {
        while (inGame)
        {
            timeCount += Time.deltaTime;
            playTime = TimeSpan.FromSeconds(timeCount);
            string timeString = "Time: " + playTime.ToString("mm':'ss'.'ff");
            LevelTimer.text = timeString;
            
            yield return null;
        }
    }

    public void beginTimer()
    {
        inGame = true;
        timeCount = 0f;
        StartCoroutine(TimerUpdate());
    }

    public void EndTimer()
    {
        inGame = false;
    }
}
