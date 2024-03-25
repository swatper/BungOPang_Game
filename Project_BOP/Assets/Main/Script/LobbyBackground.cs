using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager1 : MonoBehaviour
{
    public GameObject bopPrefabs;//Bop Prefabs Array

    void Start()
    {
        InvokeRepeating("SpawnBop", 0f, 0.7f);
    }

    //Spawn Background BOP
    void SpawnBop() {
        //Set Bop's Positon
        float posX = -10f;
        float posY = Random.Range(-4.7f, 4.7f);
        float posZ = 0;
        Vector3 pos = new Vector3(posX, posY, posZ);

        //Spawn Bop
        GameObject activeBop = Instantiate(bopPrefabs, pos, Quaternion.identity);
        activeBop.transform.parent = transform;
    }
}
