using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    //GameObject를 담을 리스트
    private List<GameObject>[] pools;

    [Header("Prefab 저장 공간")]
    //Prfab을 담을 변수
    [SerializeField] private List<GameObject> prefabs;
    
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

        return select;
    }   //오브젝트 풀링
}
