using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> roadPieces;
    float offset = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        if (roadPieces != null && roadPieces.Count > 0)
        {
            roadPieces = roadPieces.OrderBy(r => r.transform.position.z).ToList();
        }

    }
    
    public void MoveRoadPiece() {
        GameObject firstRoadPiece = roadPieces[0];
        roadPieces.Remove(firstRoadPiece);
        float roadPieceZ = roadPieces[roadPieces.Count - 1].transform.position.z + offset;
        firstRoadPiece.transform.position = new Vector3(0, 0, roadPieceZ);
        roadPieces.Add(firstRoadPiece);
    }

    // Update is called once per frame

    // void OnTriggerEnter(Collider other)
    // {
    //     transform.position = new Vector3(0,0,transform.GetChild(0).GetComponent<Renderer>().bounds.size.z * 10);
    // }
}
