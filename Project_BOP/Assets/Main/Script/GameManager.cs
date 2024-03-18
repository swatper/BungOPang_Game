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
            Debug.LogWarning("���� �ΰ� �̻��� ���� �Ŵ����� �����մϴ�.");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
       
    }
    // ���� ���� �Լ� ����
    public void AddScore(int newScore)
    {
        if (!isGameOver)
        {
            score += newScore;
            scoreText.text = (score+"M").ToString();
        }
    }
    // ��ȭ ���� �Լ� ����
    public void AddCoin(int addCoin)
    {
        if (!isGameOver)
        {
            newCoin += addCoin;
            CoinText.text = newCoin.ToString();
        }

    }
    // �÷��̾� ��� �Լ� ����(���ӿ���)
    public void OnPlayerDead()
    {
        isGameOver = true;
        gameoverUI.SetActive(true);
    }

}
