using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagers : MonoBehaviour
{
    public static GameManagers instance;

    [SerializeField]
    private int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }   //싱글톤
    private void Start()
    {
        StartCoroutine(spawn());
    }
    public void AddScore(int score)
    {
        this.score += score;
    }   //점수 추가
    //임시코드
    public void SpawnCoin()
    {
        ObjectPooling.instance.Get(0);
    }   //코인 소환
    //임시코드
    IEnumerator spawn()
    {
        while (true)
        {
            SpawnCoin();
            yield return new WaitForSeconds(1f);
        }
    }   //코인을 1초마다 소환
}
