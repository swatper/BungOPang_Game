using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Scroller : MonoBehaviour
{
    public float groundSpeed; //Speed of Ground
    public float PlayTime = 0f;
    void Start()
    {
        
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
        }
    }
}
