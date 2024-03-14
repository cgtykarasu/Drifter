using System.Collections.Generic;
using UnityEngine;

public class RoadAddController : MonoBehaviour
{
    public int roadCount = 3;
    public GameObject[] roadPrefabs;
    private List<GameObject> roads = new List<GameObject>();

    void Awake()
    {
        ConnectRoads();
    }

    void ConnectRoads()
    {
        for (int i = 0; i < roadCount; i++)
        {
            GameObject road = InstantiateRandomRoad();
            roads.Add(road);
            if (i > 0)
            {
                CombineRoads(roads[i - 1], road);
            }
        }
    }

    GameObject InstantiateRandomRoad()
    {
        int randomIndex = Random.Range(0, roadPrefabs.Length);
        return Instantiate(roadPrefabs[randomIndex], Vector3.zero, Quaternion.identity);
    }

    private void CombineRoads(GameObject firstRoad, GameObject secondRoad)
    {
        Vector3 exitPoint = firstRoad.transform.Find("Exit").position;
        Vector3 entryPoint = secondRoad.transform.Find("Entry").position;
        secondRoad.transform.position = exitPoint - entryPoint;
    }
}