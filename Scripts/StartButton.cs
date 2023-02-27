using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class StartButton : MonoBehaviour
{
    public GameObject mybtn4;
    public GameObject mybtn5;
    public GameObject background;
    public GameObject starttext;
    public GameObject player;
    public GameObject time2;
    public GameObject score2;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = mybtn4.GetComponent<Button>();
        btn.onClick.AddListener(StartGame);
        time2.GetComponent<Timer>().StopTimer();
        score2.GetComponent<Score>().StopScore();
        player.GetComponent<CharacterController>().dead = true;
        mybtn4.SetActive(true);
        mybtn5.SetActive(true);
        background.SetActive(true);
        starttext.SetActive(true);
    }

    void StartGame()
    {
        time2.GetComponent<Timer>().ResumeTimer();
        score2.GetComponent<Score>().ResumeScore();
        player.GetComponent<CharacterController>().dead = false;
        mybtn4.SetActive(false);
        mybtn5.SetActive(false);
        background.SetActive(false);
        starttext.SetActive(false);
    }
    
}
