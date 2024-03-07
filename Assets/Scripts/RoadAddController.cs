using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadAddController : MonoBehaviour
{
    public int roadCount = 3;

    public GameObject roadPrefab1;
    public GameObject roadPrefab2;
    public GameObject roadPrefab3;

    GameObject[] roadPrefabs = new GameObject[3];
    List<GameObject> roads = new List<GameObject>();

    private GameObject road1;
    private GameObject road2;
    private GameObject road3;

    Transform firstRoadExitPoint;
    Transform secondRoadEntryPoint;
    Transform secondRoadExitPoint;

    Transform thirdRoadEntryPoint;

    // Start is called before the first frame update
    void Start()
    {
        roadPrefabs[0] = roadPrefab1;
        roadPrefabs[1] = roadPrefab2;
        roadPrefabs[2] = roadPrefab3;

        // road1 = Instantiate(roadPrefab1, new Vector3(0, 0, 0), Quaternion.identity);
        // road2 = Instantiate(roadPrefab2, new Vector3(0, 0, 0), Quaternion.identity);
        // road3 = Instantiate(roadPrefab3, new Vector3(0, 0, 0), Quaternion.identity);


        for (int i = 0; i < roadCount; i++)
        {
            roads.Add(roadPrefabs[Random.Range(0, roadPrefabs.Length)]);
        }

        // {
        //     Instantiate(var, new Vector3(0, 0, 0), Quaternion.identity);
        // }

        ConnectRoad();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ConnectRoad()
    {
        // // // İlk yol parçasının son noktasını ikinci yol parçasının baş noktasına bağlayın
        // // Transform sonNokta = roadPrefab1.transform.GetChild(roadPrefab1.transform.childCount - 1);
        // // Transform basNokta = roadPrefab2.transform.GetChild(0);
        //
        // //--------------------------------------------------------------------------------
        // secondRoadEntryPoint = road2.transform.Find("Entry");
        // Debug.Log("secondRoadEntryPoint : " + secondRoadEntryPoint.position);
        // firstRoadExitPoint = road1.transform.Find("Exit");
        // Debug.Log("firstRoadExitPoint: " + firstRoadExitPoint.position);
        // // secondRoadExitPoint = road2.transform.Find("Exit");
        // // thirdRoadEntryPoint = road3.transform.Find("Entry");
        // //
        // // roads[0].transform.position = firstRoadExitPoint.position - secondRoadEntryPoint.position;
        // road2.transform.position = firstRoadExitPoint.position - secondRoadEntryPoint.position;
        // // road3.transform.position = secondRoadExitPoint.position - thirdRoadEntryPoint.position;
        // // //--------------------------------------------------------------------------------


        // Vector3 difference = secondRoadEntryPoint.position - firstRoadExitPoint.position;
        //
        // // İkinci yol parçasını birinci yol parçasının sonuna doğru hareket ettirin
        // road2.transform.position -= difference;
        //
        // // İkinci yol parçasını birinci yol parçasına bağlayın
        // for (int i = 0; i < road2.transform.childCount; i++)
        // {
        //     Transform child = road2.transform.GetChild(i);
        //     child.position -= difference;
        // }

        //--------------------------------------------------------------------------------

        // for (int i = 0; i < roads.Count - 1; i++)
        // {
        //     GameObject currentRoad = roads[i];
        //     GameObject nextRoad = roads[i + 1];
        //     
        //     Transform currentRoadExit = currentRoad.transform.Find("Exit");
        //     Transform nextRoadEntry = nextRoad.transform.Find("Entry");
        //     
        //     if (currentRoadExit != null && nextRoadEntry != null)
        //     {
        //         // nextRoad.transform.position = currentRoadExit.position - nextRoadEntry.position;
        //         nextRoad.transform.position = currentRoadExit.position - nextRoadEntry.position;
        //     }
        //     else if (currentRoadExit == null)
        //     {
        //         Debug.LogError("Current road exit point not found");
        //     }
        //     else if (nextRoadEntry == null)
        //     {
        //         Debug.LogError("Next road entry point not found");
        //     }
        // }

        // GameObject currentRoad = roads[0];
        // GameObject nextRoad = roads[1];
        // Transform currentRoadExit = currentRoad.transform.Find("Exit");
        // Transform nextRoadEntry = nextRoad.transform.Find("Entry");
        //
        // nextRoad.transform.position = currentRoadExit.position - nextRoadEntry.position;


        // // ÇALIŞAN KOD //
        // var first = Instantiate(roads[0], new Vector3(0, 0, 0), Quaternion.identity);
        // var second = Instantiate(roads[1], new Vector3(0, 0, 0), Quaternion.identity);
        // var third = Instantiate(roads[2], new Vector3(0, 0, 0), Quaternion.identity);
        //
        // firstRoadExitPoint = first.transform.Find("Exit");
        // secondRoadEntryPoint = second.transform.Find("Entry");
        // secondRoadExitPoint = second.transform.Find("Exit");
        // thirdRoadEntryPoint = third.transform.Find("Entry");
        //
        // second.transform.position = firstRoadExitPoint.position - secondRoadEntryPoint.position;
        // third.transform.position = secondRoadExitPoint.position - thirdRoadEntryPoint.position;

        //--------------------------------------------------------------------------------

        var first = Instantiate(roads[0], new Vector3(0, 0, 0), Quaternion.identity);

        for (int i = 0; i < roads.Count - 1; i++)
        {
            TwoRoadCombine(roads[i], roads[i + 1]);
        }
    }

    void TwoRoadCombine(GameObject r0, GameObject r1)
    {
        var second = Instantiate(r1, new Vector3(0, 0, 0), Quaternion.identity);

        firstRoadExitPoint = r0.transform.Find("Exit");
        Debug.Log("R0 Exit Point ::: " + firstRoadExitPoint.transform.localPosition);
        secondRoadEntryPoint = r1.transform.Find("Entry");
        Debug.Log("R1 Entry Point ::: " + firstRoadExitPoint.transform.localPosition);

        // secondRoadExitPoint = secondRoad.transform.Find("Exit"); 

        Debug.Log("R0 ÖNCESİ ::: " + r0.transform.localPosition);
        Debug.Log("R1 ÖNCESİ ::: " + r1.transform.localPosition);
        second.transform.localPosition = firstRoadExitPoint.localPosition - secondRoadEntryPoint.localPosition;
        Debug.Log("R0 SONRASI ::: " + r0.transform.localPosition);
        Debug.Log("R1 SONRASI ::: " + r1.transform.localPosition);

    }
}