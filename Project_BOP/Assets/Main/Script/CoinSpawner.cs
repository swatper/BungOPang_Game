using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public  class CoinSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public static CoinSpawner coinSpawner;
    public GameObject coinPrefab;
    private List<GameObject> newCoinslist = new List<GameObject>();
    private float reSpawnTime;
    private float spawnPosX;
    private float spawnPosY;
    private int oldCoin;
    private int currentCoin=0;
    private float levelUpTiming = 5;
    private float levelUpTimingDelta = 0;
    private void Awake()
    {
        if (coinSpawner == null)
        {
            coinSpawner = this; // Create if Game Manager is not exist.
        }
        else
        {
            Debug.LogWarning("���� �ΰ� �̻��� ���� �����ʰ� �����մϴ�.");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnCoin();
        }
        if (Input.GetMouseButtonDown(1))
        {
            RainbowCoin();
        }
        UpdateCoin();
        levelingCoin();
    }

    private void SpawnCoin()
    {
        spawnPosX = Random.Range(0, 10);
        spawnPosY = Random.Range(0, 10);

        GameObject newCoin = Instantiate(coinPrefab, new Vector3(spawnPosX, spawnPosY, 0f), Quaternion.identity);
        newCoinslist.Add(newCoin);
    }

    public void RainbowCoin()
    {
        oldCoin = currentCoin;
        currentCoin = 4;
        for (int i = newCoinslist.Count - 1; i >= 0; i--)
        {
            if (newCoinslist[i] != null) // ������ null�� �ƴ� ��쿡�� ��������Ʈ ����
            {
                oldCoin = newCoinslist[i].GetComponent<Coin>().coinNumber;
                newCoinslist[i].GetComponent<Coin>().ChangeCoin(4); // ������ ��������Ʈ ����
            }
            else
            {
                newCoinslist.RemoveAt(i); // ����Ʈ���� null�� ���� ����
            }
        }
        Invoke("RollbackCoin", 3);
    }

    private void RollbackCoin()
    {
        currentCoin = oldCoin;
    }
    private void UpdateCoin()
    {
        for (int i = newCoinslist.Count - 1; i >= 0; i--)
        {
            if (newCoinslist[i] != null) // ������ null�� �ƴ� ��쿡�� ����
            {
                newCoinslist[i].GetComponent<Coin>().ChangeCoin(currentCoin); // ������ ���� ����
            }
            else
            {
                newCoinslist.RemoveAt(i); // ����Ʈ���� null�� ���� ����
            }
        }
    }
    private void levelingCoin()
    {
        levelUpTimingDelta += Time.deltaTime;
        if (levelUpTimingDelta >= levelUpTiming)
        {
            if (currentCoin < 3)
            {
                currentCoin++;
                levelUpTimingDelta = 0;
            }
        }
    }
}
