using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    
    public GameObject coinPrefab;
    
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnCoin();
        }
    }
    
    public void SpawnCoin()
    {
        int spawnPointX = Random.Range(-90, 90);
        // int spawnPointY = Random.Range(-5, 5);
        int spawnPointZ = Random.Range(-90, 90);
        
        Vector3 spawnPosition = new Vector3(transform.position.x + spawnPointX, 2, transform.position.z + spawnPointZ);
        
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }


}
