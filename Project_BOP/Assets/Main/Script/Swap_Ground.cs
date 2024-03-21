using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Swap_Ground : MonoBehaviour
{
    public GameObject[] groundTilemaps;     //GroundTiles ObjectArray
    private int tileIndex = 0;              //Array's index
    private float seasonChangeTime = 11f;    //Time to chage Season
    public bool isGameOver = false;        //Check GamePlay Status

    private void FixedUpdate()
    {
        //Decrease Time
        if (!isGameOver)
        {
            seasonChangeTime -= Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (seasonChangeTime < 0f) {
            Invoke("ChangeGround",1.25f);
            //Reset Time
            seasonChangeTime = 11f;
        }   
    }
    void ChangeGround() {
        groundTilemaps[tileIndex].gameObject.SetActive(false);
        tileIndex += 1;
        if (tileIndex >= 4)
        {
            tileIndex = 0;
            
        }
        groundTilemaps[tileIndex].gameObject.SetActive(true);
        return;
    }
}
