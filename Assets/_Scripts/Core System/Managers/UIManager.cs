using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public IntVariable gameScore;
    public IntVariable lives;

    public Text scoreText;
    public Text livesText;
    public Text timeText;
    //public GameObject pauseButton;
    //public GameObject unpauseButton;

    private float startTime;
    private bool timerGoing = false;

    // Use this for initialization
    void Start()
    {
        StartTimer();
        UpdateLivesText();
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerGoing)
        {
            float elapsedTime = Time.time - startTime;
            string formattedTime = FormatTime(elapsedTime);
            timeText.text = formattedTime;
        }
    }

    public static string FormatTime(float elapsedTimeSeconds)
    {
        TimeSpan time = TimeSpan.FromSeconds(elapsedTimeSeconds);

        if (time.Hours < 1)
        {
            return time.ToString(@"mm\:ss");
        }
        return time.ToString("hh:mm:ss");
    }

    public void ChangeScoreText(string score)
    {
        scoreText.text = score;
    }

    public void UpdateScoreText(){
        scoreText.text = gameScore.Value.ToString();
    }

    public void ChangeLivesText(string lives)
    {
        livesText.text = lives;
    }

    public void UpdateLivesText(){
        livesText.text = lives.Value.ToString();
    }

    public void StartTimer()
    {
        startTime = Time.time;
        timerGoing = true;
    }

    public void StopTimer()
    {
        timerGoing = false;
    }

    private void OnRectTransformDimensionsChange()
    {
        //This is where we throw an event saying the orientation changed.
    }
}
