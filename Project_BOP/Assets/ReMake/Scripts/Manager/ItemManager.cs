using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;

    public List<IEatAble> eatAbles = new List<IEatAble>();

    //���� ���� ��ġ ����Ʈ
    [SerializeField]
    private List<Transform> itemTransform;

    private void Awake()
    {
        instance = this;
    }   //�̱���
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
    }   //������ ��ġ �̵�
}
