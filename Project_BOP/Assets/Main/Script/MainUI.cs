using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    // Start is called before the first frame update
    public static MainUI canvasManager;
    private Canvas canvas;
    private void Awake()
    {
        if (canvasManager == null)
        {
            canvasManager = this;
            DontDestroyOnLoad(gameObject);
            canvas = GetComponent<Canvas>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
