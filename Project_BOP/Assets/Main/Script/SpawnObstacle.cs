using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public GameObject[] obstaclePrefab;     //Obstracle Array
    public float obstacleSpeed;
    public bool isGameOver = false;
    private float seasonChangeTime = 11f;   //Time to chage Season

    void Start()
    {
        // Invoke the spawnObstacle function 
        //Call spwanObstacle After 3 seconds later and Repeat Time.deltaTime * 55.0f
        InvokeRepeating("spawnObstacle", 3f, Time.deltaTime * 55.0f);
    }

    private void FixedUpdate()
    {
        if (isGameOver) {
            return;
        }
        //Decrease time
        seasonChangeTime -= Time.deltaTime;
        if (seasonChangeTime < 0f)
        {
            seasonChangeTime = 11f;
            obstacleSpeed += 0.7f;
        }
    }
    void spawnObstacle()
    {
        float x = transform.position.x + Random.Range(13, 16);
        float y = Random.Range(-3f, 4f);
        float z = transform.position.z;
        Vector3 spawnPos = new Vector3(x, y, z);

        //Select Obstacle
        int obstacleIndex = Random.Range(0, obstaclePrefab.Length);

        GameObject newObstacle = obstaclePrefab[obstacleIndex];

        if (newObstacle == true)
        {
            if (obstacleIndex <= 1)         //0 index-> ground obstacle
            {
                spawnPos.y = -3.6f;
            }
            else if (obstacleIndex == 3)    //1 index-> floor obstacle
            {
                spawnPos.y = 4.3f;
            }
            else spawnPos.y = Random.Range(0, 2);//else -> floating in air obstacle
        }
        //Activate obstacle
        GameObject inGameObstacle = Instantiate(newObstacle, spawnPos, newObstacle.transform.rotation);
        inGameObstacle.transform.parent = transform;
        //Set activating obstacle's speed
        inGameObstacle.GetComponent<MoveObstacle>().SetSpeed(obstacleSpeed);

    }
   
}
