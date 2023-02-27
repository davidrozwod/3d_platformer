using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public GameObject tie;
    public Text scoreText;
    private float score;
    public bool updateScore;
    public bool hasScore;
    private float timeremain;
    // Start is called before the first frame update
    void Start()
    {
        hasScore = true;
        timeremain = tie.GetComponent<Timer>().timeRemaining;
        updateScore = false;
        scoreText = GetComponent<Text>();
    }

    public void StopScore()
    {
        updateScore = false;

    }
    public void ResumeScore()
    {
        updateScore = true;

    }

    void FinalScore()
    {
        if (updateScore == true)
        {

            timeremain = tie.GetComponent<Timer>().timeRemaining;
            if (timeremain > 0.0f)
            {
                score += Time.time;
                int scores = Mathf.FloorToInt(score / 550);
                scoreText.text = string.Format("Score: " + scores + " pts");
            }
        }
        else
        {

            if (hasScore == false)
            {
                int scores = Mathf.FloorToInt(score / 550);
                int seconds = Mathf.FloorToInt(timeremain % 2000);
                int total = scores + seconds;
                scoreText.text = string.Format("Score: " + total + " pts");
                hasScore = true;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        FinalScore();

    }
}
