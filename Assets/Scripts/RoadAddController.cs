using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadAddController : MonoBehaviour
{
    public int roadCount = 3;
    
    public GameObject[] roadPrefabs;
    List<GameObject> roads = new List<GameObject>();

    void Awake()
    {
        ConnectRoad();
    }


    void ConnectRoad()
    {
        // Instantiate(roadPrefabs[1], new Vector3(0, 0, 0), Quaternion.identity);
            
        for (int i = 0; i < roadCount; i++)
        {
            var road = Instantiate(roadPrefabs[Random.Range(0, roadPrefabs.Length)], new Vector3(0, 0, 0), Quaternion.identity);
            roads.Add(road);
            if (roads.Count > 1)
            {
                TwoRoadCombine(roads[i - 1], roads[i]);
            }
        }
    }

    void TwoRoadCombine(GameObject r0, GameObject r1)
    {
        //var second = Instantiate(r1, new Vector3(0, 0, 0), Quaternion.identity);
        var second = r1;
        var firstRoadExitPoint = r0.transform.Find("Exit");
        // Debug.Log("R0 Exit Point ::: " + firstRoadExitPoint.transform.position);
        var secondRoadEntryPoint = r1.transform.Find("Entry");
        // Debug.Log("R1 Entry Point ::: " + secondRoadEntryPoint.transform.position);

        // secondRoadExitPoint = secondRoad.transform.Find("Exit"); 
        // Debug.Log("R0 ÖNCESİ ::: " + r0.transform.position);
        // Debug.Log("R1 ÖNCESİ ::: " + r1.transform.position);
        
        second.transform.position = firstRoadExitPoint.position - secondRoadEntryPoint.position;
        
        // Debug.Log("R0 SONRASI ::: " + r0.transform.position);
        // Debug.Log("R1 SONRASI ::: " + r1.transform.position);
    }
}