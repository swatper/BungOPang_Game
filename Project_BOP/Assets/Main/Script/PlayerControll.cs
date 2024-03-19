using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float maxSpeed = 3f;
    private float upwardForce = 0.8f;
    private bool isDead = false;

    private Rigidbody2D playerRigidbody; // Rigidbody2D to use
    private AudioSource playerAudio; // Audio component to use
    private Transform playerTransform;
    private Animator playerAnimator;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>();
        playerTransform = GetComponent<Transform>();
        playerAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        if (isDead) // stop function if player is dead.
        {
            return;
        }
        PlayerRotate();
        // Press Space to fly
        if (Input.GetKey(KeyCode.Space))
        {
            playerRigidbody.AddForce(Vector2.up * upwardForce, ForceMode2D.Impulse);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }
    }
    private void PlayerRotate()
    {
        //if (playerRigidbody.velocityY > 1)
        //{
        //    playerAnimator.SetBool("Up", true);
        //    playerAnimator.SetBool("Down", false);
        //    playerAnimator.SetBool("Idle", false);
        //}
        //if (playerRigidbody.velocityY < -1)
        //{
        //    playerAnimator.SetBool("Up", false);
        //    playerAnimator.SetBool("Down", true);
        //    playerAnimator.SetBool("Idle", false);
        //}
        //if (playerRigidbody.velocityY < 1 && playerRigidbody.velocityY > -1)
        //{
        //    playerAnimator.SetBool("Up", false);
        //    playerAnimator.SetBool("Down", false);
        //    playerAnimator.SetBool("Idle", true);
        //}
    }
    private void Die()
    {
        playerRigidbody.velocity = Vector2.zero;
        isDead = true;
        playerRigidbody.AddForce(new Vector2(0, 1250));
        // playerAnimator.SetTrigger("Die");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle" && !isDead)
        {
            Die();
        }
    }
}