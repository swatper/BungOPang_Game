using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

//Effect is just using watersprite

public class SeasonChangeEffect : MonoBehaviour
{
    private float seasonChangeTime = 11f;    //Time to chage Season(same with season chage time)
    public float waveSpeed;                 //Sprite moving speed(more than other BackGround Spitres' speed)
    public GameObject changeEffect;         //Wave's sprite

    private void Update()
    {
        if (seasonChangeTime < 0f) {
            //Call Sprite;
            ChangeEffect();
            //Reset time
            seasonChangeTime = 11f;
        }
    }
    void FixedUpdate()
    {
        //Wave's Moving, before Seanson Change
        changeEffect.transform.Translate(waveSpeed * Time.deltaTime * -1f, 0, 0);
        //Decrease Time
        seasonChangeTime -= Time.deltaTime;
        //Stop Moving
        if (changeEffect.transform.position.x < -36f) {
            waveSpeed = 0f;
        }
    }
    void ChangeEffect() {
        //Set the wave's postion
        changeEffect.transform.Translate(56f, 0f, 0f);
        //Set the Wave's speed
        waveSpeed = 20f;
        return;
    }
}