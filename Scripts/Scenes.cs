using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public GameObject startbt;
    // Start is called before the first frame update
    void Start()
    {

        SceneManager.LoadScene("Game");

    }

}
