using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class BuyEvent : MonoBehaviour
{
    Text useText;

    void LateUpdate()
    {
        useText = GetComponent<Text>();
    }

    public void OnClickBuy(string objectName)
    {
        switch (objectName)
        {
            // Store
            case "shield":
                if (GameManager.Instance.GetTotalCoin() >= 100)
                {
                    GameManager.Instance.UseMoney(100);
                    GameManager.Instance.BuyShield();
                }
                break;

            case "flex":
                if (GameManager.Instance.GetTotalCoin() >= 100)
                {
                    GameManager.Instance.UseMoney(100);
                    GameManager.Instance.BuyFlex();
                }
                break;

            // Collection
            case "???(1)":
                if (!GameManager.Instance.GetCharacterBool(0))
                {
                    GameManager.Instance.SetCharacterBool(0);
                    GameManager.Instance.UseMoney(0);
                }
                else if (GameManager.Instance.GetCharacterBool(0))
                {
                    if (GameManager.Instance.GetCharacterNum()!= 0)
                    {
                        GameManager.Instance.SetCharacterNum(0);
                    }
                }
                break;

            case "???(2)":
                    if (!GameManager.Instance.GetCharacterBool(1))
                    {
                        if (GameManager.Instance.GetTotalCoin() >= 500)
                        {
                            GameManager.Instance.SetCharacterBool(1);
                            GameManager.Instance.UseMoney(500);
                        }
                    }
                    else if (GameManager.Instance.GetCharacterBool(1))
                    {
                        if (GameManager.Instance.GetCharacterNum() != 1)
                        {
                            GameManager.Instance.SetCharacterNum(1);
                        }
                    }
                break;

            case "???(3)":
                if (!GameManager.Instance.GetCharacterBool(2))
                {
                    if (GameManager.Instance.GetTotalCoin() >= 900)
                    {
                        GameManager.Instance.SetCharacterBool(2);
                        GameManager.Instance.UseMoney(900);
                    }
                }
                else if (GameManager.Instance.GetCharacterBool(2))
                {
                    if (GameManager.Instance.GetCharacterNum() != 2)
                    {
                        GameManager.Instance.SetCharacterNum(2);
                    }
                }
                break;
        }



    }
}
