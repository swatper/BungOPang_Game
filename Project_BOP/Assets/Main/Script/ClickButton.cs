using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class ClickButton : MonoBehaviour
{
    public Image Black;

    // Define Panel
    public GameObject GameStartPanel;
    public GameObject StorePanel;
    public GameObject ClosePanel;
    public GameObject CollectionPanel;

    public Toggle UseShield;
    public Toggle UseFlex;

    // Define Item count
    private int shieldItem = 3;
    private int flexItem = 3;

    void Start()
    {
        GameStartPanel.SetActive(false);
        StorePanel.SetActive(false);
        ClosePanel.SetActive(false);
        CollectionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButton(string buttonName)
    {
        // Perform according to the button name
        switch (buttonName)
        {
            case "GameStart":
                GameStartPanel.SetActive(true);
                ClosePanel.SetActive(true );


                break;

            case "Store":
                StorePanel.SetActive(true);
                ClosePanel.SetActive(true);
                break;

            case "Collection":
                CollectionPanel.SetActive(true);
                ClosePanel.SetActive(true);
                break;

            case "Setting":
                break;

            case "Play":

                if (UseShield != null && UseShield.isOn)
                {
                    ///////
                }

                if (UseFlex != null && UseFlex.isOn)
                {
                    ///////
                }

                ///////fadeOut();

                float loadDelay = 0.5f;
                Invoke("LoadScene", loadDelay);

                break;

            case "Buy":
                
                ///////
                break;


        }
    }

    //void fadeOut()
    //{
    //    Color color = Black.color;

    //    if (color.a < 1)
    //    {
    //        color.a += Time.deltaTime * 3;
    //        Black.color = color;

    //    }

    //}

    void LoadScene()
    {
        GameManager.Instance.isGameOver = false;
        GameManager.Instance.ActiveText();
        SceneManager.LoadScene("V2_Main_Scenes");
    }




    public void TogglePanel()
    {
        //bool GameStartState = GameStartPanel.activeSelf;
        //bool StoreState = StorePanel.activeSelf;

        

        GameStartPanel.SetActive(false);
        StorePanel.SetActive(false);
        CollectionPanel.SetActive(false);
        ClosePanel.SetActive(false);

    }




}
