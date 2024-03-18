using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float maxSpeed = 3f;   
    private float upwardForce = 1.5f;
    private bool isDead = false; 

    private Rigidbody2D playerRigidbody; // Rigidbody2D to use
    private AudioSource playerAudio; // Audio component to use
    private Transform playerTransform;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>();
        playerTransform = GetComponent<Transform>();
    }


    void Update()
    {
        if (isDead) // stop function if player is dead.
        {
            return;
        }
        // Press Space to fly
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerTransform.Rotate(0, 0, 20);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            playerRigidbody.AddForce(new Vector2(0, upwardForce));
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerTransform.Rotate(0, 0, -20);
            playerRigidbody.velocity = playerRigidbody.velocity*0.5f;
        }
    }

    private void Die()
    {
        playerRigidbody.velocity = Vector2.zero;
        isDead = true;
        DyingMotion();
    }

    private void DyingMotion() // dying motion
    {
        playerRigidbody.AddForce(new Vector2(0, 250));
        playerTransform.Rotate(0, 0, 180);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dead" && !isDead)
        {
            Die();
        }
    }

}
