using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class CollectionButton : MonoBehaviour
{
    // Start is called before the first frame updat
    public TMP_Text text1;
    public Button button;

    public enum Character
    {
        defult,
        skin1,
        skin2
    }
    public Character currentCharacter;

    void Start()
    {
        button = GetComponent<Button>();
        ButtonChoice();

    }

    // Update is called once per frame
    void Update()
    {
        ButtonChoice();
    }
    
    void ButtonChoice() 
    {
        switch (currentCharacter)
        {
            case Character.defult:
                if (!GameManager.Instance.GetCharacterBool(0))
                {
                    text1.text = "구매";
                }
                else if (GameManager.Instance.GetCharacterBool(0))
                {
                    if (GameManager.Instance.GetCharacterNum() != 0)
                    {
                        text1.text = "선택";
                        button.interactable = true;
                    }
                    else if (GameManager.Instance.GetCharacterNum() == 0)
                    {
                        text1.text = "선택됨";
                        button.interactable = false;
                        GameManager.Instance.SetCharacterNum(0);
                    }
                }
                break;
            case Character.skin1:
                if (!GameManager.Instance.GetCharacterBool(1))
                {
                    text1.text = "구매";
                }
                else if (GameManager.Instance.GetCharacterBool(1))
                {
                    if (GameManager.Instance.GetCharacterNum() != 1)
                    {
                        text1.text = "선택";
                        button.interactable = true;
                    }
                    else if (GameManager.Instance.GetCharacterNum() == 1)
                    {
                        text1.text = "선택됨";
                        button.interactable = false;
                        GameManager.Instance.SetCharacterNum(1);
                    }
                }
                break;
            case Character.skin2:
                if (!GameManager.Instance.GetCharacterBool(2))
                {
                    text1.text = "구매";
                }
                else if (GameManager.Instance.GetCharacterBool(2))
                {
                    if (GameManager.Instance.GetCharacterNum() != 2)
                    {
                        text1.text = "선택";
                        button.interactable = true;
                    }
                    else if (GameManager.Instance.GetCharacterNum() == 2)
                    {
                        text1.text = "선택됨";
                        button.interactable = false;
                        GameManager.Instance.SetCharacterNum(2);
                    }
                }
                break;
        }
    }

    
}
