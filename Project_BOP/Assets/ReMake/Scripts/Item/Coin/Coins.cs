using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour, IEatAble
{
    CoinDatas.CoinType type = CoinDatas.CoinType.Bronze;

    private int score;

    private void Start()
    {
        score = CoinDatas.GetScore(type);
    }

    public void Eat()
    {
        GameManagers.instance.AddScore(score);
        gameObject.SetActive(false);
    }
}
