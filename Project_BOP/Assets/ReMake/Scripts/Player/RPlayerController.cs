using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPlayerController : MonoBehaviour
{
    Rigidbody2D rigid;                      //물리
    Animator anim;                          //애니메이션

    [SerializeField] float jumpPower;       //점프 파워

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    //점프 구현
    public void OnJump()
    {
        Debug.Log("점프");
        rigid.velocity = Vector2.up * jumpPower;
        anim.SetTrigger("IsJump");
    }
}
