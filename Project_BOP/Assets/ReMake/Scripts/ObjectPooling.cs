using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    enum ObjectType
    {
        BronzeCoin,
        SliverCoin,
        GoldCoin,
        RainbowCoin,
    }   //오브젝트 타입 정의
    ObjectType type;   //오브젝트 타입 변수

    public static ObjectPooling instance;   //싱글톤
    private List<GameObject>[] pools;    //GameObject를 담을 리스트

    [Header("Prefab 저장 공간")]
    [SerializeField] private List<GameObject> prefabs;   //Prfab을 담을 변수

    private void Awake()
    {
        instance = this;
    }   //싱글톤
    private void Start()
    {
        pools = new List<GameObject>[prefabs.Count];

        for(int i = 0; i < prefabs.Count; i++)
        {
            pools[i] = new List<GameObject>(); 
        }
    }   //pools 초기화
    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach(GameObject item in pools[index]){
            if (!item.activeSelf)
                select = item;
        }

        if (!select){
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }
        select.SetActive(true);

        return select;
    }   //오브젝트 풀링
}
