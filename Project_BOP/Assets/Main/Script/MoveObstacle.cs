using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public float speed = 7.0f;
    public float bound = -10f;

    void Update()
    {
        //Move and destroy to obstacle
        transform.Translate( Vector3.left * speed * Time.deltaTime, Space.World);

        if (transform.position.x < bound)
        {
            Destroy(gameObject);
        }
    }
}
