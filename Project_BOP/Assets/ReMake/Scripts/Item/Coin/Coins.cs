using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour, IEatAble
{
    //�ӽ÷� ����� �������� ����
    CoinDatas.CoinType type = CoinDatas.CoinType.Bronze;

    private int score;

    private void Start()
    {
        score = CoinDatas.GetScore(type);
    }
    private void OnEnable()
    {
        ItemManager.instance.AddEatAble(this);
    }   //ItemManager�� ���
    private void OnDisable()
    {
        ItemManager.instance.RemoveEatAble(this);
    }   //ItemManager���� ����
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
