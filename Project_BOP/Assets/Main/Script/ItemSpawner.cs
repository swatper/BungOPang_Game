using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public static ItemSpawner itemSpawner;
    public GameObject shieldPrefab;
    public GameObject flexPrefab;

    private float spawnPosX;
    private float spawnPosY;
    public float itemSpeed = 10f;
    private float seasonChangeTime = 11f;

    void Start()
    {
        InvokeRepeating("SpawnItem", 3f, 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.Instance.isGameOver)
        {
            return;
        }
        seasonChangeTime -= Time.deltaTime;
        //SeasonChage and increase speed
        if (seasonChangeTime < 0f)
        {
            seasonChangeTime = 11f;
            itemSpeed += 0.7f;
        }
    }
    private void SpawnItem()
    {
        if (GameManager.Instance.isGameOver)
        {
            return;
        }
        spawnPosX = Random.Range(10, 11);
        spawnPosY = Random.Range(-3f, 4);
        if (GameManager.Instance.shieldON && GameManager.Instance.flexON)
        {
            if (Random.Range(0, 2) == 0)
            {
                GameObject itemObject = Instantiate(shieldPrefab, new Vector3(spawnPosX, spawnPosY, 0f), Quaternion.identity);
                itemObject.GetComponent<Item>().SetSpeed(itemSpeed);
            }
            else
            {
                GameObject itemObject = Instantiate(flexPrefab, new Vector3(spawnPosX, spawnPosY, 0f), Quaternion.identity);
                itemObject.GetComponent<Item>().SetSpeed(itemSpeed);
            }
        }
        else if (GameManager.Instance.shieldON)
        {
            GameObject itemObject = Instantiate(shieldPrefab, new Vector3(spawnPosX, spawnPosY, 0f), Quaternion.identity);
            itemObject.GetComponent<Item>().SetSpeed(itemSpeed);
        }
        else if (GameManager.Instance.flexON)
        {
            GameObject itemObject = Instantiate(flexPrefab, new Vector3(spawnPosX, spawnPosY, 0f), Quaternion.identity);
            itemObject.GetComponent<Item>().SetSpeed(itemSpeed);
        }
    }
}
