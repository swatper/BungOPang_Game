using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPlayerController : MonoBehaviour
{
    Rigidbody2D rigid;                      //����
    Animator anim;                          //�ִϸ��̼�

    [SerializeField] float jumpPower;       //���� �Ŀ�

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    //���� ����
    public void OnJump()
    {
        Debug.Log("����");
        rigid.velocity = Vector2.up * jumpPower;
        anim.SetTrigger("IsJump");
    }

    //Coin�̳� Item�� �Ծ�����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IEatAble eatAble))
        {
            eatAble.Eat();
        }
    }
}