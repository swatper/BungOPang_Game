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
    }   //�̱���
    private void Start()
    {
        StartCoroutine(spawn());
    }
    public void AddScore(int score)
    {
        this.score += score;
    }   //���� �߰�
    //�ӽ��ڵ�
    public void SpawnCoin()
    {
        ObjectPooling.instance.Get(0);
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
}
