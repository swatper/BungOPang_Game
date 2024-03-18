using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public bool isGameOver = false;
    public Text scoreText;
    public Text newCoinText;
    public Text totalCoinText;

    public GameObject gameoverUI;

    private int score = 0;
    private int newCoin = 0;
    private int totalCoin = 0;

    private int highScore = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다.");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddScore(int newScore)
    {
        if (!isGameOver)
        {
            score += newScore;
            scoreText.text = ("Score: " + score).ToString();
        }
    }
    public void AddCoin(int addCoin)
    {
        if (!isGameOver)
        {
            newCoin += addCoin;
            newCoinText.text = "Coin: " + newCoin;
        }

    }

    public void OnPlayerDead()
    {
        isGameOver = true;
        gameoverUI.SetActive(true);
    }
}
