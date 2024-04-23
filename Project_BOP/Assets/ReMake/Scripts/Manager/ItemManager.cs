using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;

    public List<IEatAble> eatAbles = new List<IEatAble>();

    private void Awake()
    {
        instance = this;
    }

    public void AddEatAble(IEatAble eatAble)
    {
        eatAbles.Add(eatAble);
    }

    public void RemoveEatAble(IEatAble eatAble)
    {
        eatAbles.Remove(eatAble);
    }
}
