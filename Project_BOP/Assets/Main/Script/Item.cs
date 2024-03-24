using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{   
    public float speed;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.isGameOver)
        {
            return;
        }
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
