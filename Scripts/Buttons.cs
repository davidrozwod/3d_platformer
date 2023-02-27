using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class Buttons : MonoBehaviour
{
    public Button mybtn;
    public GameObject bt2;
    public GameObject bt3;
    public GameObject player;
    public GameObject time2;
    public GameObject score2;

    // Start is called before the first frame update
    void Start()
    {
        bt2.SetActive(false);
        Button btn = mybtn.GetComponent<Button>();
        btn.onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        player.GetComponent<CharacterController>().RespawnPlayer();
        time2.GetComponent<Timer>().ResumeTimer();
        score2.GetComponent<Score>().ResumeScore();
        player.GetComponent<CharacterController>().dead = false;
        bt2.SetActive(false);
        bt3.SetActive(false);
        
    }

}
