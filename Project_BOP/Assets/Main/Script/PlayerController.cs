using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float upwardForce = 2f;
    private bool shieldOn = false;
    private Rigidbody2D playerRigidbody; // Rigidbody2D to use
    private Transform playerTransform;
    private Animator playerAnimator;
    private SpriteRenderer playerSpriteRenderer;
    public Sprite[] playerSprite;
    private int playerSpriteIndex;
    public AudioClip die;
    public AudioClip shield;
    public AudioClip flex;

    private bool invisible = false;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        // playerAudio = GetComponent<AudioSource>();
        playerTransform = GetComponent<Transform>();
        playerAnimator = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerSpriteIndex = GameManager.Instance.GetCharacterNum();
        PlayerSpriteChange(playerSpriteIndex);
    }


    void FixedUpdate()
    {
        if (GameManager.Instance.isGameOver) // stop function if player is dead.
        {
            return;
        }
        PlayerRotate();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
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
        if (GameManager.Instance.isGameOver) // stop function if player is dead.
        {
            return;
        }
        playerRigidbody.velocity = Vector2.zero;
        playerRigidbody.AddForce(new Vector2(0, 1250));
        playerAnimator.SetTrigger("Die"); //Play Die animation by setting the animator trigger to "Die"
        GameManager.Instance.OnPlayerDead(); //Run the "OnPlayerDead()" function in GameManager
    }



    private void OnTriggerEnter2D(Collider2D collision) //
    {
        if (GameManager.Instance.isGameOver) // stop function if player is dead.
        {
            return;
        }
        if (collision.tag == "Shield")
        {
            SoundManager.instance.SFXPlay("Shield");
            shieldOn = true;
            playerSpriteRenderer.sprite = playerSprite[1];
        }
        if (collision.tag == "Flex")
        {
            SoundManager.instance.SFXPlay("Flex");
            CoinSpawner.coinSpawner.RainbowCoin();
        }
        if (collision.tag == "Obstacle")
        {
            if (!invisible)
            {
                if (shieldOn)
                {
                    SoundManager.instance.SFXPlay("BRKShield");
                    invisible = true;
                    playerSpriteRenderer.color = new Color(1, 1, 1, 0.4f);
                    PlayerSpriteChange(playerSpriteIndex);
                    shieldOn =false;
                    Invoke("ShieldOff", 2);
                }
                else
                {
                    SoundManager.instance.SFXPlay("Slap");
                    Die();
                }
            }
        }
    }

    private void ShieldOff()
    {
        playerSpriteRenderer.color = new Color(1, 1, 1, 1f);
        invisible = false;
    }

    public  void PlayerSpriteChange(int index)
    {
        if(index==0)
            playerSpriteRenderer.sprite = playerSprite[index];
        else
            playerSpriteRenderer.sprite = playerSprite[index+1];
    }


}
