using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPlayerController : MonoBehaviour
{
    [SerializeField] Sprite shieldSprite;    //���� ��������Ʈ
    SpriteRenderer spriteRenderer;  //��������Ʈ ������
    Rigidbody2D rigid;  //����
    Animator anim;  //�ִϸ��̼�

    [SerializeField] float jumpPower;   //���� �Ŀ�
    bool isShield = false;  //���� ����

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }   //Component �Ҵ�
    private void OnJump()
    {
        Debug.Log("����");
        rigid.velocity = Vector2.up * jumpPower;
        anim.SetTrigger("IsJump");
    }   //���� ����
    public void OnShield()
    {
        //���� �ڷ�ƾ ����
        StartCoroutine(Shield());
    }   //���� ����
    private IEnumerator Shield()
    {
        //���� Sprite �Ҵ�
        Sprite saveSprite = spriteRenderer.sprite;
        spriteRenderer.sprite = shieldSprite;
        isShield = true;

        yield return new WaitForSeconds(5f);

        spriteRenderer.sprite = saveSprite;
        isShield = false;
        System.GC.Collect();    //������ �÷��� ��û
    }   //���� �ڷ�ƾ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IEatAble eatAble)) //������ or ���� �浹
        {
            eatAble.Eat();
        }
        //if(collision.TryGetComponent(out IObstacle obstacle)) //��ֹ� �浹
    }   //Player �浹 ó��
}
