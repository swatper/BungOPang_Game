using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionImage : MonoBehaviour
{
    public Sprite sprite;
    Image image;
    public enum States
    {
        n0,
        n1,
        n2
    }

    // enum 타입의 변수를 선언
    public States characterNum;
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (characterNum)
        {
            case States.n0:
                if (GameManager.Instance.GetCharacterBool(0))
                {
                    image.sprite = sprite;
                }
                break;
            case States.n1:
                if (GameManager.Instance.GetCharacterBool(1))
                {
                    image.sprite = sprite;
                }
                break;
            case States.n2:
                if (GameManager.Instance.GetCharacterBool(2))
                {
                    image.sprite = sprite;
                }
                break;
        }
        
    }
}
