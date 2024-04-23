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
            platformManager.MovePlatformStartPosition(other.gameObject);
        }
    }
}
