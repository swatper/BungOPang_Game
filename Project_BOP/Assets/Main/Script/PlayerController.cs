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

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>();

    }


    void Update()
    {
        if (isDead) // stop function if player is dead.
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //playerRigidbody.velocity = Vector2.zero; //包己x
        }
        if (Input.GetKey(KeyCode.Space))
        {
            playerRigidbody.AddForce(new Vector2(0, upwardForce));
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //playerRigidbody.velocity = Vector2.zero;  //包己x
            playerRigidbody.velocity = playerRigidbody.velocity*0.5f; //包己o
        }
    }

    private void Die()
    {
        playerRigidbody.velocity = Vector2.zero;
        isDead = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dead" && !isDead)
        {
            Die();
        }
    }
}
