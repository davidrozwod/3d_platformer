using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private readonly float timeLimit = 120.0f;
    public float timeRemaining;
    private Text timeText;
    public GameObject bt2;
    public GameObject character;
    public GameObject score;
    private bool updateTimer;

    // Start is called before the first frame update
    void Start()
    {
        updateTimer = false;
        timeRemaining = timeLimit;
        timeText = GetComponent<Text>();
    }
    public void StopTimer()
    {
        updateTimer = false;
    }
    public void ResumeTimer()
    {
        updateTimer = true;
    }
    // Update is called once per frame
    
    void Update()
    {
        int seconds = Mathf.FloorToInt(timeRemaining % 120);
        timeText.text = string.Format("Time Left: {0 :0}s", seconds);

        if (updateTimer == true)
        {
            // Update the timer
            timeRemaining -= Time.deltaTime;

            // Check if the time limit has been reached
            if (timeRemaining < 0)
            {
                // Reset the timer and restart the game
                StopTimer();
                character.GetComponent<CharacterController>().Death();
                score.GetComponent<Score>().hasScore = false;
                bt2.SetActive(true);

            }
        }
    }
}
