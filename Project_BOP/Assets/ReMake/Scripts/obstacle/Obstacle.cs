using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IObstacle
{
    private void OnEnable()
    {
        ObstacleManager.instance.AddObstacle(this);
    }   //ItemManager�� ���
    private void OnDisable()
    {
        ObstacleManager.instance.RemoveObstacle(this);
    }   //ItemManager���� ����
    public void Teleport(Transform position)
    {
        transform.position = position.position;
    }
}
