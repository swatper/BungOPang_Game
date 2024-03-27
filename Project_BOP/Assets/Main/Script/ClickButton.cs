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
    public GameObject LobbyUI;
    public GameObject GameStartPanel;
    public GameObject StorePanel;
    public GameObject CollectionPanel;
    public GameObject CreditScroll;
    public GameObject HowToPlayPanel;
    public GameObject ClosePanel;
    
    public Toggle UseShield;
    public Toggle UseFlex;

    void Start()
    {
        GameStartPanel.SetActive(false);
        StorePanel.SetActive(false);
        CollectionPanel.SetActive(false);
        CreditScroll.SetActive(false);
        HowToPlayPanel.SetActive(false);
        ClosePanel.SetActive(false);
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

            case "Credit":
                CreditScroll.SetActive(true);
                ClosePanel.SetActive(true);
                break;

            case "Play":
                BackgroundManager1.Instance.CallLobbyToMainEffect();
                BackgroundManager1.Instance.SetSceneStatus(false);
                GameStartPanel.SetActive(false);
                ///////fadeOut();
                Invoke("LoadScene",0f);

                break;

            case "HowToPlay":
                HowToPlayPanel.SetActive(true);
                ClosePanel.SetActive(true);
                GameStartPanel.SetActive(false);
                StorePanel.SetActive(false);
                CollectionPanel.SetActive(false);
                CreditScroll.SetActive(false);
                break;
        }
    }

    

    void LoadScene()
    {
        SceneManager.LoadScene("V2_Main_Scenes");
        GameManager.Instance.ActiveText();
        GameManager.Instance.isGameOver = false;
        LobbyUI.SetActive(false);

    }




    public void TogglePanel()
    {
        //bool GameStartState = GameStartPanel.activeSelf;
        //bool StoreState = StorePanel.activeSelf;

        GameStartPanel.SetActive(false);
        StorePanel.SetActive(false);
        CollectionPanel.SetActive(false);
        CreditScroll.SetActive(false);
        HowToPlayPanel.SetActive(false);
        ClosePanel.SetActive(false);

    }

}
