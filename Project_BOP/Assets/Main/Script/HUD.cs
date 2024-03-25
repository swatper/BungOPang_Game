using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
   public enum InfoType { BestScore, Coin, ShieldItem, FlexItem }
   public InfoType type;


    //change after murge
    public int BestScore = 0;
    public int Coin = 0;
    public int ShieldItem = 0;
    public int FlexItem = 0;

    Text myText;

    private void Awake()
    {
        myText = GetComponent<Text>();
    }

    void Update()
    {
        switch (type)
        {
            case InfoType.BestScore:
                //myText.text = "BestScore: " + GameManager.instance.GetScore();
                myText.text = "�ְ� ���� " + BestScore;
                break;

            case InfoType.Coin:
                //myText.text = "Coin: " + GameManager.instance.GetCoin();
                myText.text = "�� " + Coin;
                break;

            case InfoType.ShieldItem:
                //myText.text = "ShieldItem: " + GameManager.instance.GetShieldItem();
                myText.text = ShieldItem.ToString();
                break;

            case InfoType.FlexItem:
                //myText.text = "FlexItem: " + GameManager.instance.GetFlexItem();
                myText.text = FlexItem.ToString();
                break;

            
        }
        BestScore = GameManager.Instance.GetHighscore();
        Coin = GameManager.Instance.GetTotalCoin();
    }
}
