using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public float speed;
    public float bound = -20f;
    public bool isGameover = false;
    private GameObject playerObject;        //PlayerObject to check player's status

    void FixedUpdate()
    {
        transform.Translate( Vector3.left * speed * Time.deltaTime, Space.World);

        if (transform.position.x < bound)
        {
            Destroy(gameObject);
        }
    }
    public void SetSpeed(float speed) { 
        this.speed = speed;
    }
}
