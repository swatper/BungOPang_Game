using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public 변수 선언
    public float force = 0.5f;
    public float maxSpeed = 5f;

    // 인스턴스 생성
    Rigidbody2D rigidBody;
    Animator animator;

    // 컴포넌트 호출
    void Awake()
    {
        //RigidBody2D 호출
        rigidBody = GetComponent<Rigidbody2D>();
        //Animator 호출
        animator = GetComponent<Animator>();
    }


    //애니메이션 관련 로직
    void Update()
    {
        // 스페이스 키가 눌리면 상승으로 판단, 애니메이션 트렌지션 파라미터 값 조정
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("KeyDownSpace", true);
            animator.SetBool("KeyUpSpace", false);
            animator.SetBool("Idle", false);
        }
        // 스페이스 키가 떼어지면 하강으로 판단, 애니메이션 트렌지션 파라미터 값 조정
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("KeyDownSpace", false);
            animator.SetBool("KeyUpSpace", true);
            animator.SetBool("Idle", false);
        }

    }

    //물리 관련 로직
    void FixedUpdate()
    {
        // 스페이스키 입력 -> 플레이어 점프 함수 실행
        if (Input.GetKey(KeyCode.Space))
        {
            PlayerJump();
        }

        // 스프라이트의 Y 속도가 음수 -> 플레이어 착지 함수 실행
        if (rigidBody.velocityY < 0)
        {
            PlayerLanding();
        }
    }

  // 플레이어 점프(상승)
    void PlayerJump()
    {
        // 위 쪽으로 힘 작용
        rigidBody.AddForce(Vector2.up * force, ForceMode2D.Impulse);

        // 플레이어의 최대 속도 제한
        if (rigidBody.velocity.y > maxSpeed)
        {
            rigidBody.velocity = new Vector2(0, maxSpeed);
        }
    }

  // 플레이어 착지
    void PlayerLanding()
    {
        // 플레이어 기준 하단으로 가상의 선 그리기
        Debug.DrawRay(rigidBody.position, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D raycastHit2D = Physics2D.Raycast(rigidBody.position, Vector3.down, 1, LayerMask.GetMask("platform"));

        // 선이 바닥(platform)에 닿으면 착지로 판단, 애니메이션 트렌지션 파라미터 값 조정
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