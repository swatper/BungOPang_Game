using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.UI;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //Button GameStart;

    public void OnClickGameStart()
    {
        Debug.Log("Game Start");
        SceneManager.LoadScene("SampleScene");
    }

    void Start()
    {
        //ameStart = GetComponent<Button>();
        //GameStart.onClick.AddListener(OnClickGameStart);
    }

    public void OnClickCollection()
    {
        Debug.Log("Collection");
    }


    public void OnClickStore()
    {
        Debug.Log("Store");
    }

    public void OnClickCredit()
    {
        Debug.Log("Credit");
    }

    public void OnClickQuit()
    {
        // End Game _ !! In Unity !!
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#else
        Application.Quit();
#endif
    }

}
