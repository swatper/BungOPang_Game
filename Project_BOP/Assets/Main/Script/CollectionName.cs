using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;

public class CollectionName : MonoBehaviour
{
    // Start is called before the first frame update
    public enum States
    {
        n0,
        n1,
        n2
    }
    public States characterNum;
    TMP_Text text;
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (characterNum)
        {
            case States.n0:
                if (GameManager.Instance.GetCharacterBool(0))
                {
     //
                }
                break;
            case States.n1:
                if (GameManager.Instance.GetCharacterBool(1))
                {
                    text.text = "¿ÕºØ»§";
                }
                break;
            case States.n2:
                if (GameManager.Instance.GetCharacterBool(2))
                {
                    text.text = "ÇØÀûºØ";
                }
                break;
        }
    }
}
