using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    
    RoadSpawner roadSpawner;
    
    // Start is called before the first frame update
    void Start()
    {
        roadSpawner = GetComponent<RoadSpawner>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SpawnTriggerEntered()
    {
        roadSpawner.MoveRoadPiece();
    }
}
