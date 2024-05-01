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
    }   //������Ʈ Ÿ�� ����
    ObjectType type;   //������Ʈ Ÿ�� ����

    public static ObjectPooling instance;   //�̱���
    private List<GameObject>[] pools;    //GameObject�� ���� ����Ʈ

    [Header("Prefab ���� ����")]
    [SerializeField] private List<GameObject> prefabs;   //Prfab�� ���� ����

    private void Awake()
    {
        instance = this;
    }   //�̱���
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
        select.SetActive(true);

        return select;
    }   //������Ʈ Ǯ��
}
