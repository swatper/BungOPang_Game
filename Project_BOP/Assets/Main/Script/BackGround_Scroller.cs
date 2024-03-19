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
    private float seasonChangeTime = 5f;   //PlayTime to chage Season

    void Start()
    {
        oldObjectSprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() 
    {
        transform.Translate(playSpeed * Time.fixedDeltaTime * -1f, 0, 0);
        seasonChangeTime-= Time.fixedDeltaTime;
    }
    void Update()
    {
        //After 10 seconds, Change Sprite(= Change Seasons)
        if (seasonChangeTime < 0f)
        {
            ChangeSprite();
            Debug.Log("Season Canged!!");
            seasonChangeTime = 5f;
        }
    }

    //Replace the backGround object
    private void LateUpdate()
    {
        if (transform.position.x <= -18) { 
            transform.Translate(36f, 0, 0,Space.Self);
        }
    }

    //Change backGroud obeject sprite funtion
    public void ChangeSprite() {
        oldObjectSprite.sprite = newObjextSprite01[spriteIndex];
        spriteIndex += 1;
        if (spriteIndex >= 4)
        {
            spriteIndex = 0;
        }
    }
}
