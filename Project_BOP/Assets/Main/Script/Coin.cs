using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class Coin : MonoBehaviour
{
    public enum coinStates
    {
        Nomal,
        Bronze,
        Silver,
        Gold,
        Rainbow
    }
    public int coinNumber;
    public coinStates currentState;
    public SpriteRenderer coinSpriteRenderer;
    public Sprite[] coinSprite;
    public float speed;

    public AudioClip addCoin;


    // Start is called before the first frame update
    void Awake()
    {
        ChangeCoinSprite();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.Instance.isGameOver) {
            return;
        }
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
        ChangeCoinSprite();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AddCoin();
        }
    }
    private void ChangeCoinSprite()
    {
        switch (currentState)
        {
            case coinStates.Nomal:
                coinSpriteRenderer.sprite = coinSprite[0];
                break;
            case coinStates.Bronze:
                coinSpriteRenderer.sprite = coinSprite[1];
                break;
            case coinStates.Silver:
                coinSpriteRenderer.sprite = coinSprite[2];
                break;
            case coinStates.Gold:
                coinSpriteRenderer.sprite = coinSprite[3];
                break;
            case coinStates.Rainbow:
                coinSpriteRenderer.sprite = coinSprite[4];
                break;
        }
    }
    private void AddCoin()
    {
        SoundManager.instance.SFXPlay("AddCoin", addCoin);

        switch (currentState)
        {
            case coinStates.Nomal:
                GameManager.Instance.AddCoin(1);
                break;
            case coinStates.Bronze:
                GameManager.Instance.AddCoin(2);
                break;
            case coinStates.Silver:
                GameManager.Instance.AddCoin(3);
                break;
            case coinStates.Gold:
                GameManager.Instance.AddCoin(4);
                break;
            case coinStates.Rainbow:
                GameManager.Instance.AddCoin(5);
                break;
        }
        Destroy(gameObject);
    }

    public void ChangeCoin(int newCoinNumber)
    {
        switch (newCoinNumber)
        {
            case 0:
                currentState = coinStates.Nomal;
                coinNumber = 0;
                break;
            case 1:
                currentState = coinStates.Bronze;
                coinNumber = 1;
                break;
            case 2:
                currentState = coinStates.Silver;
                coinNumber = 2;
                break;
            case 3:
                currentState = coinStates.Gold;
                coinNumber = 3;
                break;
            case 4:
                currentState = coinStates.Rainbow;
                coinNumber = 4;
                break;
        }
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
