using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatas : MonoBehaviour
{
    public static ItemDatas instance;
    public List<ItemData> itemDatas = new List<ItemData>();

    private void Awake()
    {
        instance = this;
    }   //ΩÃ±€≈Ê
    public enum ItemType
    {
        FeverTime,
        Shield,
    } // æ∆¿Ã≈€ ≈∏¿‘ ¡§¿«

}
