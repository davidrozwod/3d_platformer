using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatMove2 : MonoBehaviour
{
    private readonly float speed = 5f;
    private readonly float moveDistance = 20f;
    private readonly bool moveRight = false;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = transform;
        }
    }


    // Stop moving the character along with the platform
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
    void Update()
    {
        // Determine the direction of movement
        int direction = moveRight ? 1 : -1;

        // Calculate the new position of the platform
        Vector3 newPosition = new(startPosition.x + direction * Mathf.PingPong(Time.time * speed, moveDistance),
                                          transform.position.y,
                                          transform.position.z);

        // Set the new position of the platform
        transform.position = newPosition;
    }
}

