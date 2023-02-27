using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    public GameObject checkpointFlag; // A game object representing the checkpoint flag
    public GameObject playersys;

    public bool checkpointReached = false; // A flag indicating whether the player has reached the checkpoint

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !checkpointReached)
        {
            // Set the checkpoint flag and mark the checkpoint as reached
            checkpointFlag.SetActive(true);
            checkpointReached = true;
            playersys.GetComponent<CharacterController>().SetCheckpoint(transform.position);
            playersys.GetComponent<CharacterController>().SavePlayerPosition(playersys.transform.position);
        }
    }
}

