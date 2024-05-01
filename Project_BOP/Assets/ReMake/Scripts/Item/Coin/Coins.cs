using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour, IEatAble
{
    [SerializeField] CoinDatas.CoinType type;   //코인 타입 지정

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
