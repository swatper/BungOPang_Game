using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
   public enum InfoType { BestScore, Coin, ShieldItem, FlexItem }
    public InfoType type;

    //change after murge
    public int BestScore = 10000;
    public int Coin = 10000;
    public int ShieldItem = 10;
    public int FlexItem = 10;

    



    Text myText;

    private void Awake()
    {
        myText = GetComponent<Text>();
    }

    void LateUpdate()
    {
        switch (type)
        {
            case InfoType.BestScore:
                //myText.text = "BestScore: " + GameManager.instance.GetScore();
                myText.text = "Best Score: " + BestScore;
                break;

            case InfoType.Coin:
                //myText.text = "Coin: " + GameManager.instance.GetCoin();
                myText.text = "Coin: " + Coin;
                break;

            case InfoType.ShieldItem:
                //myText.text = "ShieldItem: " + GameManager.instance.GetShieldItem();
                myText.text = "99";
                break;

            case InfoType.FlexItem:
                //myText.text = "FlexItem: " + GameManager.instance.GetFlexItem();
                myText.text = "99";
                break;

            
        }   

    }
}
