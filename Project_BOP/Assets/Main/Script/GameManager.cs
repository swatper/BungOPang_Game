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
    public TMP_Text CoinText;
    public TMP_Text totalCoinText;

    public GameObject gameoverUI;

    public int score = 0;
    public int newCoin = 0;
    private int totalCoin = 0;
    private int highScore = 0;

    private void Awake()
    {
        if (Instance == null)
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
    // 점수 증가 함수 정의
    public void AddScore(int newScore)
    {
        if (!isGameOver)
        {
            score += newScore;
            scoreText.text = (score+"M").ToString();
        }
    }
    // 재화 증가 함수 정의
    public void AddCoin(int addCoin)
    {
        if (!isGameOver)
        {
            newCoin += addCoin;
            CoinText.text = newCoin.ToString();
        }

    }
    // 플레이어 사망 함수 정의(게임오버)
    public void OnPlayerDead()
    {
        isGameOver = true;
        gameoverUI.SetActive(true);
    }

}
