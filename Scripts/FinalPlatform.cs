using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalPlatform : MonoBehaviour
{
    public GameObject bt3;
    public GameObject character;
    public GameObject score;
    public GameObject background;
    public GameObject endtext;


    private void Start()
    {
        background.SetActive(false);
        endtext.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            character.GetComponent<CharacterController>().Death();
            score.GetComponent<Score>().hasScore = false;
            bt3.SetActive(false);
            background.SetActive(true);
            endtext.SetActive(true);
        }
    }
  
  


}
