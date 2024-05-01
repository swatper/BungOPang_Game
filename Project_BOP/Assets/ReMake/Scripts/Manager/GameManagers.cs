using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagers : MonoBehaviour
{
    public static GameManagers instance;    //�̱���

    private enum GameState
    {
        Level1,
        Level2,
        Level3,
        FeverTime,
        GameOver,
    }   //���� ���� ����
    [SerializeField] private GameState gameState;   //���� ����
    [SerializeField] private int score;  //����
    [SerializeField] private float time = 0;    //���� �ð�

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }   //�̱���
    private void Start()
    {
        gameState = GameState.Level1;
        StartCoroutine(spawn());
    }   //Level1�� ����
    public void AddScore(int score)
    {
        this.score += score;
    }   //���� �߰�
    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
    }   //���� �ð� ����
    public void StartFeverTime()
    {
        StartCoroutine(FeverTime());
    }   //�ǹ�Ÿ�� �ڷ�ƾ ����
    private IEnumerator FeverTime()
    {
        GameState saveGameState = gameState;
        gameState = GameState.FeverTime;
        yield return new WaitForSeconds(10f);
        gameState = saveGameState;
    }   //�ǹ�Ÿ��

    //�ӽ��ڵ�
    public void SpawnCoin()
    {
        ObjectPooling.instance.Get((int)gameState);
    }   //���� ��ȯ
    //�ӽ��ڵ�
    IEnumerator spawn()
    {
        while (true)
        {
            SpawnCoin();
            yield return new WaitForSeconds(1f);
        }
    }   //������ 1�ʸ��� ��ȯ
    //�ӽ��ڵ�
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
    }   //spaceŰ�� ������ gameState�� 1�� ����
}
