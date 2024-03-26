using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
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
                Debug.Log("+1 Shield");
                GameManager.Instance.UseMoney(100);
                GameManager.Instance.BuyShield();
                break;

            case "flex":
                GameManager.Instance.UseMoney(100);
                GameManager.Instance.BuyFlex();
                break;

            // Collection
            case "???(1)":

                break;

            case "???(2)":

                break;

            case "???(3)":

                break;
        }



    }
}
