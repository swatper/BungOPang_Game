using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager instance;

    public List<IObstacle> obstacles = new List<IObstacle>();

    //코인 스폰 위치 리스트
    [SerializeField]
    private List<Transform> obstacleTransform;

    private void Awake()
    {
        instance = this;
    }   //싱글톤
    public void AddObstacle(IObstacle obstacle)
    {
        this.obstacles.Add(obstacle);
        TeleportItem(obstacle);
    }
    public void RemoveObstacle(IObstacle obstacle)
    {
        this.obstacles.Remove(obstacle);
    }
    private void TeleportItem(IObstacle obstacle)
    {
        int rand = Random.Range(0, obstacleTransform.Count);
        obstacle.Teleport(obstacleTransform[rand]);
    }   //아이템 위치 이동
}
