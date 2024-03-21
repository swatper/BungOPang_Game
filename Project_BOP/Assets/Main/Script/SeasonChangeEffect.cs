using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

//Effect is just using watersprite

public class SeasonChangeEffect : MonoBehaviour
{
    private float seasonChangeTime = 11f;    //Time to chage Season(same with season chage time)
    public float waveSpeed;                 //Sprite moving speed(more than other BackGround Spitres' speed)
    public float upSpeed = 0.7f;
    public int ChangeTimes = 0;
    public bool isGameOver = false;        //Check GamePlay Status
    public GameObject changeEffect;         //Wave's sprite

    private void Update()
    {
        if (seasonChangeTime < 0f) {
            ChangeTimes++;
            //Call Sprite;
            ChangeEffect();
            //Reset time
            seasonChangeTime = 11f;
        }
    }
    void FixedUpdate()
    {
        //Stop Moving
        if (changeEffect.transform.position.x < -36f || isGameOver)
        {
            return;
        }
        //Wave's Moving, before Seanson Change
        changeEffect.transform.Translate(waveSpeed * Time.deltaTime * -1f, 0, 0);
        //Decrease Time
        seasonChangeTime -= Time.deltaTime;
    }
    void ChangeEffect() {
        //Set the wave's postion
        changeEffect.transform.Translate(56f, 0f, 0f);
        //Set the Wave's speed
        waveSpeed = 20f + ChangeTimes * ChangeTimes;
        return;
    }
}
