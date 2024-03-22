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
            Debug.LogWarning("씬에 두개 이상의 코인 스포너가 존재합니다.");
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
            if (newCoinslist[i] != null) // 코인이 null이 아닌 경우에만 스프라이트 변경
            {
                oldCoin = newCoinslist[i].GetComponent<Coin>().coinNumber;
                newCoinslist[i].GetComponent<Coin>().ChangeCoin(4); // 코인의 스프라이트 변경
            }
            else
            {
                newCoinslist.RemoveAt(i); // 리스트에서 null인 코인 제거
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
            if (newCoinslist[i] != null) // 코인이 null이 아닌 경우에만 변경
            {
                newCoinslist[i].GetComponent<Coin>().ChangeCoin(currentCoin); // 코인의 상태 변경
            }
            else
            {
                newCoinslist.RemoveAt(i); // 리스트에서 null인 코인 제거
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
