using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    public bool isGameOver = false;        //Check GamePlay Status

    // Start is called before the first frame update

    private void Awake()
    {
    }

    //GamePause
    void Update()
    {
        if (isGameOver)
        {
            Time.timeScale = 0f;
        }
        else {
            Time.timeScale = 1f;
        }
    }
    

}
