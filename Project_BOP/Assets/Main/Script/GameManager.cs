using JetBrains.Annotations;
using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isGameOver = true;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public TMP_Text CoinText;
    public TMP_Text totalCoinText;
    public TMP_Text gameoverCoinText;
    public TMP_Text gameoverScoreText;
    public GameObject gameoverUI;
    public GameObject TextUI;
    public float score = 0;
    public int newCoin = 0;
    private int totalCoin = 99999;
    private int highScore = 0;
    public bool shieldON = false;
    public bool flexON=false;
    private void Start()
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
        isGameOver = true;
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
            scoreText.text = ("현재 점수 "+(int)score).ToString();
        }
        if (score > highScore)
        {
            highScore = (int)score;
            highScoreText.text = ("최고 점수 " + highScore).ToString();
        }
    }
    // 재화 증가 함수 정의
    public void AddCoin(int addCoin)
    {
        if (!isGameOver)
        {
            newCoin += addCoin;
            CoinText.text = ("얻은 팥 "+newCoin).ToString();
        }

    }
    // 플레이어 사망 함수 정의(게임오버)
    public void OnPlayerDead()
    {
        isGameOver = true;
        gameoverUI.SetActive(true);
        gameoverCoinText.text = ("+ : " + newCoin).ToString();
        gameoverScoreText.text = ("현재 점수 "+(int)score).ToString();
        if (score > highScore)
        {
            highScore = (int)score;
            highScoreText.text = ("최고 점수 "+ highScore).ToString();
        }
        SoundManager.instance.SFXPlay("GameOver");


    }

    public void OnClickButton()
    {
        TotalCoin();
        SceneManager.LoadScene("LobbyScene");
        InactiveText();
    }
    private void InactiveText()
    {
        TextUI.SetActive(false);
        gameoverUI.SetActive(false);
    }
    public void ActiveText()
    {
        TextUI.SetActive(true);
    }

    public void TotalCoin()
    {
        score = 0;
        totalCoin += newCoin;
        newCoin = 0;
        totalCoinText.text = ("전체 팥 " + totalCoin).ToString();
        CoinText.text=("얻은 팥 " + newCoin).ToString();
    }

    public int GetTotalCoin()
    {
        return totalCoin;
    }
    public int GetHighscore()
    {
        return highScore;
    }
    public void UseMoney(int price) { 
        totalCoin -= price;
    }
}
