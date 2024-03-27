using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager1 : MonoBehaviour
{

    public static BackgroundManager1 Instance;
    public GameObject bopPrefabs;//Bop Prefabs Array
    public GameObject lobbyToMainEffect;
    public bool isGameStart = false;
    public bool isLobbyScene = true;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this; // Create if Game Manager is not exist.
        }
        else
        {
            Destroy(gameObject);
        }
        InvokeRepeating("SpawnBop", 0f, 0.7f);
    }
    private void FixedUpdate()
    {
        if (isGameStart) {
            CallLobbyToMainEffect();
            isGameStart = false;
        }
    }

    //Spawn Background BOP
    void SpawnBop() {
        if (!isLobbyScene) {
            
            return;
        }
        //Set Bop's Positon
        float posX = -10f;
        float posY = Random.Range(-4.7f, 4.7f);
        float posZ = 0;
        Vector3 pos = new Vector3(posX, posY, posZ);

        //Spawn Bop
        GameObject activeBop = Instantiate(bopPrefabs, pos, Quaternion.identity);
        activeBop.transform.parent = transform;
    }
    public void CallLobbyToMainEffect() {
        Instantiate(lobbyToMainEffect);
    }
    public void SetSceneStatus(bool isLobbyScene) { 
        this.isLobbyScene = isLobbyScene;
    }
}
