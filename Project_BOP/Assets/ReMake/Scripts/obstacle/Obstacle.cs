using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IObstacle
{
    private void OnEnable()
    {
        ObstacleManager.instance.AddObstacle(this);
    }   //ItemManager에 등록
    private void OnDisable()
    {
        ObstacleManager.instance.RemoveObstacle(this);
    }   //ItemManager에서 제거
    public void Teleport(Transform position)
    {
        transform.position = position.position;
    }
}
