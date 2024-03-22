using JetBrains.Annotations;
using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isGameOver = false;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public TMP_Text CoinText;
    public TMP_Text totalCoinText;
    public TMP_Text gameoverCoinText;
    public TMP_Text gameoverScoreText;
    public GameObject gameoverUI;

    public float score = 0;
    public int newCoin = 0;
    private int totalCoin = 0;
    private int highScore = 0;
    private int oldCoin;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Create if Game Manager is not exist.
        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다.");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (isGameOver)
        {
            return;
        }
        AddScore(); // 
    }
    // 점수 증가 함수 정의
    public void AddScore()
    {
        if (!isGameOver)
        {
            
            score += (Time.deltaTime * 12);
            scoreText.text = ("Score: "+(int)score).ToString();
        }
        if (score > highScore)
        {
            highScore = (int)score;
            highScoreText.text = ("High Score: " + highScore).ToString();
        }
    }
    // 재화 증가 함수 정의
    public void AddCoin(int addCoin)
    {
        if (!isGameOver)
        {
            newCoin += addCoin;
            CoinText.text = ("Plus coin: "+newCoin).ToString();
        }

    }
    // 플레이어 사망 함수 정의(게임오버)
    public void OnPlayerDead()
    {
        isGameOver = true;
        gameoverUI.SetActive(true);
        gameoverCoinText.text = ("@: " + newCoin).ToString();
        gameoverScoreText.text = ("Score: "+(int)score).ToString();
        if (score > highScore)
        {
            highScore = (int)score;
            highScoreText.text = ("High Score:"+ highScore).ToString();
        }
        totalCoin += newCoin;
        totalCoinText.text = ("Total coin: " + totalCoin).ToString();
    }
}
