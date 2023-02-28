using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.TextCore.Text;

public class Door : MonoBehaviour
{
    public GameObject skullPrefab; // The prefab for the skull
    
    public float shootTimer;
    public float skullSpeed = 5f; // The speed at which the skull moves
    public float maxDistance = 10f; // The maximum distance the skull can travel before being destroyed
    public float shootCooldown = 1f;


    public void ShootSkull()
    {
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }

        if (shootTimer <= 0) {

            Vector3 skullPosition = transform.position + -transform.forward; // 2f is an example offset value
            GameObject skullParent = new("Skull Parent");
            skullParent.transform.parent = transform;
            // Create a new instance of the skull prefab at the calculated position
            GameObject skull = Instantiate(skullPrefab, skullPosition, transform.rotation, skullParent.transform);

            // Get the rigidbody component of the skull
            Rigidbody skullRigidbody = skull.GetComponent<Rigidbody>();

            // Set the velocity of the skull to move in the forward direction of the door with the specified speed
            skullRigidbody.velocity = -transform.forward * skullSpeed;

            shootTimer = shootCooldown;
            // Destroy the skull parent object after the skull has traveled the maximum distance
            Destroy(skullParent, maxDistance / skullSpeed);

        }
    }

    

    private void Update()
    {
        ShootSkull();
    }
}

