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

    public coinStates currentState;
    public SpriteRenderer coinSpriteRenderer;
    public Sprite[] coinSprite;
    // Start is called before the first frame update
    void Awake()
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

    // Update is called once per frame
    void Update()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            switch (currentState)
            {
                case coinStates.Nomal:
                    coinSpriteRenderer.sprite = coinSprite[0];
                    GameManager.Instance.AddCoin(1);
                    break;
                case coinStates.Bronze:
                    coinSpriteRenderer.sprite = coinSprite[1];
                    GameManager.Instance.AddCoin(2);
                    break;
                case coinStates.Silver:
                    coinSpriteRenderer.sprite = coinSprite[2];
                    GameManager.Instance.AddCoin(3);
                    break;
                case coinStates.Gold:
                    coinSpriteRenderer.sprite = coinSprite[3];
                    GameManager.Instance.AddCoin(4);
                    break;
                case coinStates.Rainbow:
                    coinSpriteRenderer.sprite = coinSprite[4];
                    GameManager.Instance.AddCoin(5);
                    break;
            }
            Destroy(gameObject);
        }
    }

}
