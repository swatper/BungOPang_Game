using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDatas : MonoBehaviour
{
    public static CoinDatas instance;

    private void Awake()
    {
        instance = this;
    } //싱글톤
    public enum CoinType
    {
        Bronze,
        Sliver,
        Gold,
        Rainbow,
    } // 코인 타입 정의
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
    } //코인 타입에 따른 점수 반환
}
