using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public ���� ����
    public float force = 0.5f;
    public float maxSpeed = 5f;

    // �ν��Ͻ� ����
    Rigidbody2D rigidBody;
    Animator animator;

    // ������Ʈ ȣ��
    void Awake()
    {
        //RigidBody2D ȣ��
        rigidBody = GetComponent<Rigidbody2D>();
        //Animator ȣ��
        animator = GetComponent<Animator>();
    }


    //�ִϸ��̼� ���� ����
    void Update()
    {
        // �����̽� Ű�� ������ ������� �Ǵ�, �ִϸ��̼� Ʈ������ �Ķ���� �� ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("KeyDownSpace", true);
            animator.SetBool("KeyUpSpace", false);
            animator.SetBool("Idle", false);
        }
        // �����̽� Ű�� �������� �ϰ����� �Ǵ�, �ִϸ��̼� Ʈ������ �Ķ���� �� ����
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("KeyDownSpace", false);
            animator.SetBool("KeyUpSpace", true);
            animator.SetBool("Idle", false);
        }

    }

    //���� ���� ����
    void FixedUpdate()
    {
        // �����̽�Ű �Է� -> �÷��̾� ���� �Լ� ����
        if (Input.GetKey(KeyCode.Space))
        {
            PlayerJump();
        }

        // ��������Ʈ�� Y �ӵ��� ���� -> �÷��̾� ���� �Լ� ����
        if (rigidBody.velocityY < 0)
        {
            PlayerLanding();
        }
    }

  // �÷��̾� ����(���)
    void PlayerJump()
    {
        // �� ������ �� �ۿ�
        rigidBody.AddForce(Vector2.up * force, ForceMode2D.Impulse);

        // �÷��̾��� �ִ� �ӵ� ����
        if (rigidBody.velocity.y > maxSpeed)
        {
            rigidBody.velocity = new Vector2(0, maxSpeed);
        }
    }

  // �÷��̾� ����
    void PlayerLanding()
    {
        // �÷��̾� ���� �ϴ����� ������ �� �׸���
        Debug.DrawRay(rigidBody.position, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D raycastHit2D = Physics2D.Raycast(rigidBody.position, Vector3.down, 1, LayerMask.GetMask("platform"));

        // ���� �ٴ�(platform)�� ������ ������ �Ǵ�, �ִϸ��̼� Ʈ������ �Ķ���� �� ����
        if (raycastHit2D.collider != null)
        {
            if (raycastHit2D.distance < 1f)
            {
                animator.SetBool("KeyDownSpace", false);
                animator.SetBool("KeyUpSpace", false);
                animator.SetBool("Idle", true);
            }
        }

    }
}