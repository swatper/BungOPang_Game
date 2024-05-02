using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPlayerController : MonoBehaviour
{
    [SerializeField] Sprite shieldSprite;    //쉴드 스프라이트
    SpriteRenderer spriteRenderer;  //스프라이트 렌더러
    Rigidbody2D rigid;  //물리
    Animator anim;  //애니메이션

    [SerializeField] float jumpPower;   //점프 파워
    bool isShield = false;  //쉴드 상태

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }   //Component 할당
    private void OnJump()
    {
        Debug.Log("점프");
        rigid.velocity = Vector2.up * jumpPower;
        anim.SetTrigger("IsJump");
    }   //점프 구현
    public void OnShield()
    {
        //쉴드 코루틴 시작
        StartCoroutine(Shield());
    }   //쉴드 구현
    private IEnumerator Shield()
    {
        //쉴드 Sprite 할당
        Sprite saveSprite = spriteRenderer.sprite;
        spriteRenderer.sprite = shieldSprite;
        isShield = true;

        yield return new WaitForSeconds(5f);

        spriteRenderer.sprite = saveSprite;
        isShield = false;
        System.GC.Collect();    //가비지 컬렉션 요청
    }   //쉴드 코루틴
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IEatAble eatAble)) //아이템 or 코인 충돌
        {
            eatAble.Eat();
        }
        //if(collision.TryGetComponent(out IObstacle obstacle)) //장애물 충돌
    }   //Player 충돌 처리
}
