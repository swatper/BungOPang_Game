using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public GameObject[] obstaclePrefab;

    void Start()
    {
        // repeat spawnObstacle 
        InvokeRepeating("spawnObstacle", Time.deltaTime *  10.0f, Time.deltaTime * 30.0f);
    }


    void spawnObstacle()  
    {
        // define Vector3 spawnPos

        float x = transform.position.x;
        float y = Random.Range(-3f, 4f);
        float z = transform.position.z;
        Vector3 spawnPos = new Vector3(x, y, z);


        int obstacleIndex = Random.Range(0, obstaclePrefab.Length);


        GameObject newObstacle = obstaclePrefab[obstacleIndex];

        if (newObstacle == true)
        {
            if (obstacleIndex == 0)
            {
                spawnPos.y = -3.05f;
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
