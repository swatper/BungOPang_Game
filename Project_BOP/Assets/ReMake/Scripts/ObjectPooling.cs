using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    //GameObject�� ���� ����Ʈ
    private List<GameObject>[] pools;

    [Header("Prefab ���� ����")]
    //Prfab�� ���� ����
    [SerializeField] private List<GameObject> prefabs;
    
    private void Start()
    {
        pools = new List<GameObject>[prefabs.Count];

        for(int i = 0; i < prefabs.Count; i++)
        {
            pools[i] = new List<GameObject>(); 
        }
    }   //pools �ʱ�ȭ
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
    }   //������Ʈ Ǯ��
}
