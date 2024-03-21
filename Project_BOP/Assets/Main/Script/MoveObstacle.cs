using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    //int destroyObs = 0;
    public float speed;
    public float bound = -20f;

    void FixedUpdate()
    {
        transform.Translate( Vector3.left * speed * Time.deltaTime, Space.World);

        if (transform.position.x < bound)
        {
            Destroy(gameObject);
        }
    }
    
}
