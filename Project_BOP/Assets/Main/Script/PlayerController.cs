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
        //RigidBody2D ����
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        PlayerJump();
    }

    // �÷��̾� ���� �Լ�
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