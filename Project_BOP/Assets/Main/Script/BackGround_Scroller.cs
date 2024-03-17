using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BackGround_Scroller : MonoBehaviour
{
    public float groundSpeed; //Speed of Ground
    public SpriteRenderer oldObjectSprite; //Target Object's Old Sprite
    public Sprite newObjextSprite01;       //Target Object's New Sprite
    void Start()
    {
        oldObjectSprite = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate() //Increas speed
    {
        
    }
    void Update()
    {
        transform.Translate(groundSpeed * Time.deltaTime * -1f, 0, 0);
    }
    private void LateUpdate()
    {
        if (transform.position.x <= -18) { //Replace Ground
            transform.Translate(36f, 0, 0,Space.Self);
            switch (transform.tag)
            {
                case "Tree":
                    //Image Change
                    oldObjectSprite.sprite = newObjextSprite01;
                    break;
                default:
                    break;
            }
        }
    }
}
