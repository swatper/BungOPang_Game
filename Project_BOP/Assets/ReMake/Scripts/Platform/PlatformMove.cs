using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    Rigidbody2D rigid;

    [SerializeField] private float speed;        //ÇÃ·¿Æû ÀÌµ¿ ¼Óµµ

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rigid.velocity = Vector2.left * speed;
    }
}
