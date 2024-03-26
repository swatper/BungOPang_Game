using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyToMainEffect : MonoBehaviour
{
    // Start is called before the first frame update
    private float effectSpeed = 22f;
    void Start()
    {
        Vector3 pos = new Vector3(-13.3f, -9.3f, 0f);
        transform.position = pos;
        transform.rotation = Quaternion.Euler(0f,0f,-50f);
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(-Vector3.left * effectSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.up * (effectSpeed - 5f) * Time.deltaTime, Space.World);
        if (transform.position.x > 20f)
        {
            Destroy(gameObject);
        }
    }
}
