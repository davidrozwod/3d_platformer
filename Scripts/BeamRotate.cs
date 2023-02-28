using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamRotate : MonoBehaviour
{

    public float rotationSpeed = 50f; // Rotation speed in degrees per second
    public float pushForce = 100f; // Force to push the player sideways

    private Rigidbody rb; // Reference to the Rigidbody component

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.TryGetComponent<Rigidbody>(out var playerRigidbody))
            {
                // Apply a force to push the player sideways
                Vector3 pushDirection = collision.contacts[0].normal;
                playerRigidbody.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            }
        }
    }   

    void FixedUpdate()
    {
        // Rotate the beam around the y-axis
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, rotationSpeed * Time.fixedDeltaTime, 0f));
    }
}

