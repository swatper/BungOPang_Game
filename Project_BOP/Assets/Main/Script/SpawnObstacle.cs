using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public GameObject[] obstaclePrefab;

    void Start()
    {
        // Invoke the spawnObstacle function 

        InvokeRepeating("spawnObstacle", Time.deltaTime *  10.0f, Time.deltaTime * 57.0f);
    }


    void spawnObstacle()  
    {
        float x = transform.position.x + Random.Range(13, 16);
        float y = Random.Range(-3f, 4f);
        float z = transform.position.z;
        Vector3 spawnPos = new Vector3(x, y, z);


        int obstacleIndex = Random.Range(0, obstaclePrefab.Length);


        GameObject newObstacle = obstaclePrefab[obstacleIndex];

        if (newObstacle == true)
        {
            if (obstacleIndex == 0)
            {
                spawnPos.y = -3.6f;
            }
            else if (obstacleIndex == 3)
            {
                spawnPos.y = 4.2f;
            }
            else spawnPos.y = Random.Range(0, 2);
        }

        Instantiate(newObstacle, spawnPos, newObstacle.transform.rotation);
    }
}
