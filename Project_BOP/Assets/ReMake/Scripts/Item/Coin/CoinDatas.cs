using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDatas : MonoBehaviour
{
    public static CoinDatas instance;

    private void Awake()
    {
        instance = this;
    }

    public enum CoinType
    {
        Bronze,
        Sliver,
        Gold,
        Rainbow,
    }
    
    public static int GetScore(CoinType type)
    {
        switch (type)
        {
            case CoinType.Bronze:
                return 100;
            case CoinType.Sliver:
                return 200;
            case CoinType.Gold:
                return 300;
            case CoinType.Rainbow:
                return 500;
            default:
                return 0;
        }
    }
}
