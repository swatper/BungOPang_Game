using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private Transform platformStartPosition;

    public void MovePlatformStartPosition(GameObject platform)
    {
        Vector3 platformPosition = platform.transform.position;
        platformPosition.x = platformStartPosition.position.x;
        Debug.Log(platformPosition);
        platform.transform.position = platformPosition;
    }
}
