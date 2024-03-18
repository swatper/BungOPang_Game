using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float maxSpeed = 3f;   
    private float upwardForce = 0.8f;
    private bool isDead = false;
    private bool shieldOn = false;
    private bool coinX2 = false;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
        if (Input.GetKey(KeyCode.Space))
        {
            playerRigidbody.AddForce(Vector2.up*upwardForce, ForceMode2D.Impulse);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerRigidbody.velocity = playerRigidbody.velocity*0.5f;
        }
    }
    private void PlayerRotate()
    {
        if (playerRigidbody.velocityY > 1)
        {
            playerAnimator.SetBool("Up", true);
            playerAnimator.SetBool("Down", false);
            playerAnimator.SetBool("Idle", false);
        }
        if(playerRigidbody.velocityY < -1)
        {
            playerAnimator.SetBool("Up", false);
            playerAnimator.SetBool("Down", true);
            playerAnimator.SetBool("Idle", false);
        }
        if(playerRigidbody.velocityY < 1 && playerRigidbody.velocityY > -1)
        {
            playerAnimator.SetBool("Up", false);
            playerAnimator.SetBool("Down", false);
            playerAnimator.SetBool("Idle", true);
        }
    }


    private void Die()
    {
        playerRigidbody.velocity = Vector2.zero;
        isDead = true;
        playerRigidbody.AddForce(new Vector2(0, 1250));
        playerAnimator.SetTrigger("Die");
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle" && !isDead)
        {

            if (!shieldOn)
            {
                Die();
            }
        }
        if (collision.tag == "Coin" && !isDead)
        {
            //게임매니저로 재화 올리기.
            if (coinX2)
            {
                GameManager.Instance.AddCoin(10);
            }
            else
            {
                GameManager.Instance.AddCoin(5);
            }
        }
        if (collision.tag == "Shield" && !isDead)
        {
            shieldOn = true;
        }
        if (collision.tag == "CoinX2" && !isDead)
        {
            coinX2 = true;
         
            // 게임매니저가 코인 2배 메소드 실행하게 하기.
        }

    }

}
