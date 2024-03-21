using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float maxSpeed = 3f;
    private float upwardForce = 0.8f;
    private bool isDead = false;
    private bool shieldOn = false;
    private Rigidbody2D playerRigidbody; // Rigidbody2D to use
    private AudioSource playerAudio; // Audio component to use
    private Transform playerTransform;
    private Animator playerAnimator;
    private SpriteRenderer playerSpriteRenderer;
    public Sprite[] playerSprite;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>();
        playerTransform = GetComponent<Transform>();
        playerAnimator = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (isDead) // stop function if player is dead.
        {
            return;
        }
        PlayerRotate();
        
        // Press Space to fly)
        if (Input.GetKey(KeyCode.Space)) 
        {
            playerRigidbody.AddForce(Vector2.up * upwardForce, ForceMode2D.Impulse); // Rise while pressing the space bar
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }
    }
    private void PlayerRotate() // Player animation transformation
    {
        if (playerRigidbody.velocityY > 1) //Play Up animation when player velocityY is greater than 1
        {
            playerAnimator.SetBool("Up", true);
            playerAnimator.SetBool("Down", false);
            playerAnimator.SetBool("Idle", false);
        }
        if (playerRigidbody.velocityY < -1) //Play Down animation when player velocityY is lower than -1
        {
            playerAnimator.SetBool("Up", false);
            playerAnimator.SetBool("Down", true);
            playerAnimator.SetBool("Idle", false);
        }
        if (playerRigidbody.velocityY < 1 && playerRigidbody.velocityY > -1)//Play Down animation when player velocityY is  than greater than -1 or lower than 1
        {
            playerAnimator.SetBool("Up", false);
            playerAnimator.SetBool("Down", false);
            playerAnimator.SetBool("Idle", true);
        }
    }


    private void Die() // Function that runs when a player dies
    {
        playerRigidbody.velocity = Vector2.zero;
        isDead = true;
        playerRigidbody.AddForce(new Vector2(0, 1250));
        playerAnimator.SetTrigger("Die"); //Play Die animation by setting the animator trigger to "Die"
        GameManager.Instance.OnPlayerDead(); //Run the "OnPlayerDead()" function in GameManager
    }



    private void OnTriggerEnter2D(Collider2D collision) //
    {
        if (collision.tag == "Shield" && !isDead)
        {
            shieldOn = true;
            playerSpriteRenderer.sprite = playerSprite[1];
        }
        if (collision.tag == "CoinX2" && !isDead)
        {
            GameManager.Instance.CoinX2();
        }
        if (collision.tag == "Obstacle" && !isDead)
        {
            if (shieldOn)
            {
                playerSpriteRenderer.color = new Color(1, 1, 1, 0.4f);
                playerSpriteRenderer.sprite = playerSprite[0];
                Invoke("ShieldOff", 2);
            }
            else
            {
                Die();
            }
        }
    }

    private void ShieldOff()
    {
        playerSpriteRenderer.color = new Color(1, 1, 1, 1f);
        shieldOn = false;
    }



}
