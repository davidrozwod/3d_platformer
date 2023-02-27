using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Skull : MonoBehaviour
{
    public GameObject character2;

    private void Start()
    {
        character2 = GameObject.FindWithTag("Player");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            character2.GetComponent<CharacterController>().Death();
        }
    }
}
