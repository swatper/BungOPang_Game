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
    public GameObject LobbyUI;
    public float score = 0;
    public int newCoin = 0;
    private int totalCoin = 99999;
    private int highScore = 0;
    public bool shieldON = false;
    public bool flexON = false;
    private int shieldItem = 0;
    private int flexItem = 0;
    public Toggle shieldToggle; // Shield 토글
    public Toggle flexToggle; // Flex 토글

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this; // Create if Game Manager is not exist.
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        isGameOver = true;
        shieldToggle.onValueChanged.AddListener(OnShieldToggleChanged);
        flexToggle.onValueChanged.AddListener(OnFlexToggleChanged);
    }


    void FixedUpdate()
    {
        CheckItem();
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
            scoreText.text = ("Score: " + (int)score).ToString();
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
            CoinText.text = ("Plus coin: " + newCoin).ToString();
        }

    }
    // 플레이어 사망 함수 정의(게임오버)
    public void OnPlayerDead()
    {
        UseItme();
        isGameOver = true;
        gameoverUI.SetActive(true);
        gameoverCoinText.text = ("+ : " + newCoin).ToString();
        gameoverScoreText.text = ("Score: " + (int)score).ToString();
        if (score > highScore)
        {
            highScore = (int)score;
            highScoreText.text = ("High Score:" + highScore).ToString();
        }


    }

    public void OnClickButton()
    {
        TotalCoin();
        SceneManager.LoadScene("LobbyScene_KGB");
        LobbyUI.SetActive(true);
        InactiveText();
        BackgroundManager1.Instance.SetSceneStatus(true);
    }
    public void OnClickReStartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameoverUI.SetActive(false);
        TotalCoin();
        isGameOver = false;
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
        totalCoinText.text = ("Total coin: " + totalCoin).ToString();
        CoinText.text = ("Plus coin: " + newCoin).ToString();
    }

    public int GetTotalCoin()
    {
        return totalCoin;
    }
    public int GetHighscore()
    {
        return highScore;
    }
    public void UseMoney(int price)
    {
        totalCoin -= price;
    }
    public int GetShieldItem()
    {
        return shieldItem;
    }
    public int GetFlexItem()
    {
        return flexItem;
    }
    public void BuyShield()
    {
        shieldItem += 10;
    }
    public void BuyFlex()
    {
        flexItem += 10;
    }

    public void OnShieldToggleChanged(bool Value1)
    {
        shieldON = Value1;
    }

    public void OnFlexToggleChanged(bool Value2)
    {
        flexON = Value2;
    }
    private void UseItme()
    {
        if (shieldON)
        {
            shieldItem -= 1;
        }
        if (flexON)
        {
            flexItem -= 1;
        }
    }
    private void CheckItem()
    {
        if (shieldItem <= 0)
        {
            shieldToggle.isOn = false;
            shieldToggle.interactable = false;
        }
        else if(shieldItem >= 1)
        {
            shieldToggle.interactable = true;
        }
        if (flexItem <= 0)
        {
            flexToggle.isOn = false;
            flexToggle.interactable = false;
        }
        else if(flexItem >= 1)
        {
            flexToggle.interactable = true;
        }
    }
}