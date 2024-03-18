using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 변수
    private float maxSpeed = 3f;   
    private float upwardForce = 0.8f;
    private bool isDead = false;
    private bool shieldOn = false;
    private bool coinX2 = false;

    private Rigidbody2D playerRigidbody; // Rigidbody2D to use
    private AudioSource playerAudio; // Audio component to use
    private Transform playerTransform;
    private Animator playerAnimator;

    // 컴포넌트 호출
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>();
        playerTransform = GetComponent<Transform>();
        playerAnimator = GetComponent<Animator>();
    }

    // 플레이어 이동
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

    // 플레이어 회전 모션 함수 정의
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

    // 플레이어 사망 함수 정의
    private void Die()
    {
        playerRigidbody.velocity = Vector2.zero;
        isDead = true;
        playerRigidbody.AddForce(new Vector2(0, 1250));
        playerAnimator.SetTrigger("Die");

        GameManager.Instance.OnPlayerDead();
    }


    // 플레이어 충돌 트리거
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 장애물과 충돌
        if (collision.tag == "Obstacle" && !isDead)
        {

            if (!shieldOn)
            {
                Die();
            }
        }
        // 코인과 충돌
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
        // 쉴드 아이템과 충돌
        if (collision.tag == "Shield" && !isDead)
        {
            shieldOn = true;
        }
        // 재화 2배 아이템과 충돌
        if (collision.tag == "CoinX2" && !isDead)
        {
            coinX2 = true;
            
        }

    }

}
