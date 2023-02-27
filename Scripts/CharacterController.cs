using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public float movementSpeed = 4.0f;
    public float jumpForce = 1200.0f;
    public float strafeSpeed = 4f;
    public float backSpeed = 4f;
    public float jumpTimer;
    public float jumpCooldown = 0.5f;
    public float deathY = 1.0f;
    public GameObject playerObject;
    public GameObject time;
    public GameObject bt2;
    public GameObject bt3;
    public GameObject score;
    public GameObject plat;
    public GameObject skull;
    public GameObject checkpot;
    public AudioSource audioSource2;
    private Animator animator;
    private Rigidbody rb;
    //private bool isGrounded;
    private bool isMovingForward = false;
    public bool dead;
    private bool isStrafingLeft = false;
    private bool isStrafingRight = false;
    private bool isWalkingBackwards = false;
    private bool isWalkingBackwardsLeft = false;
    private bool isWalkingBackwardsRight = false;
    private bool isMovingForwardLeft = false;
    private bool isMovingForwardRight = false;
    


    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerObject.transform.position = new Vector3(-0.5f,6,12);
        SetCheckpoint(transform.position);
    }
    public void SavePlayerPosition(Vector3 position)
    {
        // Save the player's position to PlayerPrefs
        PlayerPrefs.SetFloat("PlayerX", position.x);
        PlayerPrefs.SetFloat("PlayerY", position.y);
        PlayerPrefs.SetFloat("PlayerZ", position.z);
    }

    public void SetCheckpoint(Vector3 position)
    {
        // Save the checkpoint position to PlayerPrefs
        PlayerPrefs.SetFloat("CheckpointX", position.x);
        PlayerPrefs.SetFloat("CheckpointY", position.y);
        PlayerPrefs.SetFloat("CheckpointZ", position.z);
    }

    public void RespawnPlayer()
    {
        // Load the checkpoint position from PlayerPrefs
        float checkpointX = PlayerPrefs.GetFloat("CheckpointX");
        float checkpointZ = PlayerPrefs.GetFloat("CheckpointZ");

        // Set the player's position to the checkpoint position
        playerObject.transform.position = new Vector3(checkpointX, 5, checkpointZ);
    }
    public void Death()
    {
        time.GetComponent<Timer>().StopTimer();
        score.GetComponent<Score>().StopScore();
        if (checkpot.GetComponent<Checkpoint>().checkpointReached == true)
        {
            bt2.SetActive(true);
        } 
        bt3.SetActive(true);
        dead = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < deathY)
        {
            Death();
        }
        if (!dead)
        {
            // Handle character jumping
            if (Input.GetButtonDown("Jump") && jumpTimer <= 0)
            {
                animator.SetTrigger("jumpTrigger");
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                audioSource2.Play();
                jumpTimer = jumpCooldown;
            }

            if (jumpTimer > 0)
            {
                jumpTimer -= Time.deltaTime;
            }
        }
 
    }

    void FixedUpdate()
    {
        if (!dead)
        {
            // Handle character movement
            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");

            Vector3 movementDirection = new(horizontalMovement, 0.0f, verticalMovement);
            movementDirection = transform.TransformDirection(movementDirection);
            movementDirection *= movementSpeed;

            rb.velocity = new Vector3(movementDirection.x, rb.velocity.y, movementDirection.z);


            if (horizontalMovement < 0 && verticalMovement == 0)
            {
                isStrafingLeft = true;
                isStrafingRight = false;
                animator.SetBool("isStrafingLeft", isStrafingLeft);
                animator.SetBool("isStrafingRight", isStrafingRight);
                rb.AddForce(transform.right * -strafeSpeed);
            }
            else if (horizontalMovement > 0 && verticalMovement == 0)
            {
                isStrafingLeft = false;
                isStrafingRight = true;
                animator.SetBool("isStrafingLeft", isStrafingLeft);
                animator.SetBool("isStrafingRight", isStrafingRight);
                rb.AddForce(transform.right * -strafeSpeed);
            }
            else
            {
                isStrafingLeft = false;
                isStrafingRight = false;
                animator.SetBool("isStrafingLeft", isStrafingLeft);
                animator.SetBool("isStrafingRight", isStrafingRight);
                rb.AddForce(movementDirection * movementSpeed);
            }

            if (verticalMovement < 0)
            {
                if (horizontalMovement < 0)
                {
                    isWalkingBackwardsLeft = true;
                    isWalkingBackwardsRight = false;
                    animator.SetBool("isWalkingBackwardsLeft", isWalkingBackwardsLeft);
                    animator.SetBool("isWalkingBackwardsRight", isWalkingBackwardsRight);
                    rb.AddForce(-transform.right * strafeSpeed);
                }
                else if (horizontalMovement > 0)
                {
                    isWalkingBackwardsLeft = false;
                    isWalkingBackwardsRight = true;
                    animator.SetBool("isWalkingBackwardsLeft", isWalkingBackwardsLeft);
                    animator.SetBool("isWalkingBackwardsRight", isWalkingBackwardsRight);
                    rb.AddForce(transform.right * strafeSpeed);
                }
                else
                {
                    isWalkingBackwards = true;
                    isWalkingBackwardsLeft = false;
                    isWalkingBackwardsRight = false;
                    animator.SetBool("isWalkingBackwards", isWalkingBackwards);
                    animator.SetBool("isWalkingBackwardsLeft", isWalkingBackwardsLeft);
                    animator.SetBool("isWalkingBackwardsRight", isWalkingBackwardsRight);
                    rb.AddForce(transform.forward * -backSpeed);
                }
            }
            else
            {
                isWalkingBackwards = false;
                isWalkingBackwardsLeft = false;
                isWalkingBackwardsRight = false;
                animator.SetBool("isWalkingBackwards", isWalkingBackwards);
                animator.SetBool("isWalkingBackwardsLeft", isWalkingBackwardsLeft);
                animator.SetBool("isWalkingBackwardsRight", isWalkingBackwardsRight);
            }



            if (verticalMovement > 0)
            {
                if (horizontalMovement < 0)
                {
                    isMovingForwardLeft = false;
                    isMovingForwardRight = true;
                    animator.SetBool("isMovingForwardLeft", isMovingForwardLeft);
                    animator.SetBool("isMovingForwardRight", isMovingForwardRight);
                    rb.AddForce(-transform.right * strafeSpeed);
                }
                else if (horizontalMovement > 0)
                {
                    isMovingForwardLeft = true;
                    isMovingForwardRight = false;
                    animator.SetBool("isMovingForwardLeft", isMovingForwardLeft);
                    animator.SetBool("isMovingForwardRight", isMovingForwardRight);
                    rb.AddForce(transform.right * strafeSpeed);
                }
                else
                {
                    isMovingForwardRight = false;
                    isMovingForwardLeft = false;
                    isMovingForward = true;
                    animator.SetBool("isMovingForwardLeft", isMovingForwardLeft);
                    animator.SetBool("isMovingForwardRight", isMovingForwardRight);
                    animator.SetBool("isMovingForward", isMovingForward);
                }
            }
            else
            {
                isMovingForward = false;
                isMovingForwardLeft = false;
                isMovingForwardRight = false;
                animator.SetBool("isMovingForward", isMovingForward);
                animator.SetBool("isMovingForwardLeft", isMovingForwardLeft);
                animator.SetBool("isMovingForwardRight", isMovingForwardRight);
            }
        }
    }
}
