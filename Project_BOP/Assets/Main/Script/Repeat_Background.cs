using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Repeat_Background : MonoBehaviour
{
    private Vector3 startPos;
    public float speed;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < startPos.x - 20.48f)
        {
            transform.position = startPos;
        }
    }
}
