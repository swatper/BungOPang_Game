using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager instance;

    public List<IObstacle> obstacles = new List<IObstacle>();

    //���� ���� ��ġ ����Ʈ
    [SerializeField]
    private List<Transform> obstacleTransform;

    private void Awake()
    {
        instance = this;
    }   //�̱���
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
    }   //������ ��ġ �̵�
}
