using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void OnTriggerEnter(Collider other)
    {
        transform.position = new Vector3(0,0,transform.GetChild(0).GetComponent<Renderer>().bounds.size.z * 9);
    }
}
