using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour, IEatAble
{
    //임시로 브론즈 코인으로 설정
    CoinDatas.CoinType type = CoinDatas.CoinType.Bronze;

    private int score;

    private void Start()
    {
        score = CoinDatas.GetScore(type);
    }
    private void OnEnable()
    {
        ItemManager.instance.AddEatAble(this);
    }   //ItemManager에 등록
    private void OnDisable()
    {
        ItemManager.instance.RemoveEatAble(this);
    }   //ItemManager에서 제거
    public void Eat()
    {   
        GameManagers.instance.AddScore(score);
        gameObject.SetActive(false);
    }
    public void Teleport(Transform position)
    {
        transform.position = position.position;
    }
}
