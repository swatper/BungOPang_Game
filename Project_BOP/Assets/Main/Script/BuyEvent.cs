using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuyEvent : MonoBehaviour
{
    public void OnClickBuy(string objectName)
    {
        switch (objectName)
        {
            // Store
            case "shield":
                Debug.Log("+1 Shield");
                break;

            case "flex":
                
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
