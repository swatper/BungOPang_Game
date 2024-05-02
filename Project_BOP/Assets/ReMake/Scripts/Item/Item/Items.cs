using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour, IEatAble
{
    [SerializeField]private ItemDatas.ItemType type;

    private void OnEnable()
    {
        ItemManager.instance.AddEatAble(this);
    }   //ItemManager�� ���
    private void OnDisable()
    {
        ItemManager.instance.RemoveEatAble(this);
    }   //ItemManager���� ����
    public void Eat()
    {
        switch (type)
        {
            case ItemDatas.ItemType.FeverTime:
                FeverTimeItem();
                break;
            case ItemDatas.ItemType.Shield:
                ShieldItem();
                break;
        }
        gameObject.SetActive(false);
    }
    public void Teleport(Transform position)
    {
        transform.position = position.position;
    }
    private void FeverTimeItem()
    {
        GameManagers.instance.StartFeverTime();
    }   //FeverTime ������ ���
    private void ShieldItem()
    {
        GameManagers.instance.player.OnShield();
    }   //Shield ������ ���
}
