using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class ExitButton : MonoBehaviour
{
    public GameObject mybtn5;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = mybtn5.GetComponent<Button>();
        btn.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
    void ExitGame()
    {
        Application.Quit();
    }
}
