using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagers : MonoBehaviour
{
    public static GameManagers instance;    //싱글톤

    private enum GameState
    {
        Level1,
        Level2,
        Level3,
        FeverTime,
        GameOver,
    }   //게임 레벨 정의
    [SerializeField] private GameState gameState;   //게임 상태
    [SerializeField] private int score;  //점수
    [SerializeField] private float time = 0;    //게임 시간

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }   //싱글톤
    private void Start()
    {
        gameState = GameState.Level1;
        StartCoroutine(spawn());
    }   //Level1로 시작
    public void AddScore(int score)
    {
        this.score += score;
    }   //점수 추가
    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
    }   //게임 시간 측정
    public void StartFeverTime()
    {
        StartCoroutine(FeverTime());
    }   //피버타임 코루틴 시작
    private IEnumerator FeverTime()
    {
        GameState saveGameState = gameState;
        gameState = GameState.FeverTime;
        yield return new WaitForSeconds(10f);
        gameState = saveGameState;
    }   //피버타임

    //임시코드
    public void SpawnCoin()
    {
        ObjectPooling.instance.Get((int)gameState);
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
    //임시코드
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameState += 1;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ObjectPooling.instance.Get(4);
        }
    }   //space키를 누르면 gameState를 1씩 증가
}
