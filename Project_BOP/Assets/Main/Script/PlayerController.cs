using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float force = 0.5f;
    public float maxSpeed = 5f;
    Rigidbody2D rigidBody;

    void Awake()
    {
        //RigidBody2D 선언
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        PlayerJump();
    }

    // 플레이어 비행 함수
    void PlayerJump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddForce(transform.up * force, ForceMode2D.Impulse);
            if (rigidBody.velocity.y > maxSpeed)
            {
                rigidBody.velocity = new Vector2(0, maxSpeed);
            }

        }
    }
}