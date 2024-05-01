using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEndPosition : MonoBehaviour
{
    [SerializeField]private PlatformManager platformManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlatformMove other = collision.GetComponent<PlatformMove>();
        if(other != null)
        {
            if (collision.GetComponent<IEatAble>() != null){
                collision.gameObject.SetActive(false);
                return;
            }
          
            platformManager.MovePlatformStartPosition(other.gameObject);
        }
    }   //플랫폼이 끝에 도달하면 플랫폼의 시작 위치로 이동
}
