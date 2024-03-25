using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public float speed;
    public float bound = -20f;

    void FixedUpdate()
    {
        if (GameManager.Instance.isGameOver)
        {
            return;
        }
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
