using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;

    public List<IEatAble> eatAbles = new List<IEatAble>();

    //코인 스폰 위치 리스트
    [SerializeField]
    private List<Transform> itemTransform;

    private void Awake()
    {
        instance = this;
    }   //싱글톤
    public void AddEatAble(IEatAble eatAble)
    {
        eatAbles.Add(eatAble);
        TeleportItem(eatAble);
    }
    public void RemoveEatAble(IEatAble eatAble)
    {
        eatAbles.Remove(eatAble);
    }
    private void TeleportItem(IEatAble eatAble)
    {
        int rand = Random.Range(0, itemTransform.Count);
        eatAble.Teleport(itemTransform[rand]);
    }   //아이템 위치 이동
}
