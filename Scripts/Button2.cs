using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

public class Button2 : MonoBehaviour
{
    public Button mybtn2;
    public GameObject bt3;
    void Start()
    {
        bt3.SetActive(false);
        Button btn = mybtn2.GetComponent<Button>();
        btn.onClick.AddListener(RestartGame);
    }

    // Update is called once per frame
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
