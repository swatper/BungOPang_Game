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
    private float levelUpTiming = 16f;
    private float levelUpTimingDelta = 0;
    public float coinSpeed = 10f;
    private float seasonChangeTime = 11f;   //Time to chage Season


    void Start()
    {
        InvokeRepeating("SpawnCoin", 3f, 0.7f);
    }
    private void SpawnCoin()
    {
        if (GameManager.Instance.isGameOver)
        {
            return;
        }
        spawnPosX = Random.Range(10, 11);
        spawnPosY = Random.Range(-3f, 4);

        GameObject newCoin = Instantiate(coinPrefab, new Vector3(spawnPosX, spawnPosY, 0f), Quaternion.identity);
        newCoin.transform.parent = transform;

        newCoin.GetComponent<Coin>().SetSpeed(coinSpeed);

        newCoinslist.Add(newCoin);
    }
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
    void FixedUpdate()
    {
        if (GameManager.Instance.isGameOver) {
            return;
        }
        UpdateCoin();
        levelingCoin();
        //Decrease time
        seasonChangeTime -= Time.deltaTime;
        //SeasonChage and increase speed
        if (seasonChangeTime < 0f)
        {
            seasonChangeTime = 11f;
            coinSpeed += 0.7f;
        }
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
                newCoinslist[i].GetComponent<Coin>().SetSpeed(coinSpeed);
            }
            else
            {
                newCoinslist.RemoveAt(i); // ����Ʈ���� null�� ���� ����
            }
        }
    }
    private void levelingCoin()
    {
        levelUpTimingDelta += Time.fixedDeltaTime;
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
