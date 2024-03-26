using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyBOPMoving : MonoBehaviour
{
    public Sprite[] bopSprites;
    public SpriteRenderer bopRenderer;
    private int spriteIndex = 0;
    private float bopMovingSpeed;
    void Awake()
    {
        bopRenderer = GetComponent<SpriteRenderer>();

        //Set BOP's position
        bopMovingSpeed = Random.Range(2, 10);
        spriteIndex = Random.Range(0, 29);

        //Select BOP's Sprite
        bopRenderer.sprite = bopSprites[spriteIndex];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        transform.Translate(-Vector3.left * bopMovingSpeed * Time.deltaTime, Space.World);
        if (transform.position.x > 10f) { 
            Destroy(gameObject);    
        }
    }
}
