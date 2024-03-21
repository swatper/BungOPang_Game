using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BackGround_Scroller : MonoBehaviour
{
    public SpriteRenderer oldObjectSprite;   //Object's Old Sprite
    public Sprite[] newObjextSprite01;       //Object's New Sprite Array
    public float playSpeed;                 //Speed of Ground
    private int spriteIndex = 1;            //Sprite Array's index
    private float seasonChangeTime = 11f;   //Time to chage Season
    public bool isGameOver = false;        //Check GamePlay Status

    void Start()
    {
        oldObjectSprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        //Stop scrolling
        if (isGameOver)
        {
            return;
        }
        //Decrease time
        seasonChangeTime -= Time.fixedDeltaTime;
        transform.Translate(playSpeed * Time.deltaTime * -1f, 0, 0);
    }
    void Update()
    {
        //Change Sprite(= Change Seasons)
        if (seasonChangeTime < 0f)
        {
            //Call sprite change funtion, after 0.5 seconds later
            Invoke("ChangeSeason" , 1.25f);
            seasonChangeTime = 11f;
            playSpeed += 0.7f;
        }
    }

    //Replace BackGround object
    private void LateUpdate()
    {
        if (transform.position.x <= -18)
        {
            transform.Translate(36f, 0, 0, Space.Self);
        }
    }

    //Change BackGroud obeject sprite funtion
    public void ChangeSeason()
    {
        if (newObjextSprite01.Length == 0)
        {
            return;
        }
        oldObjectSprite.sprite = newObjextSprite01[spriteIndex];
        spriteIndex += 1;
        if (spriteIndex >= 4)
        {
            spriteIndex = 0;
        }
        return;
    }
}