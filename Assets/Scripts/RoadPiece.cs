using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPiece : MonoBehaviour
{

    public Transform entry;
    public Transform exit;

    public void Place (RoadPiece previousPiece)
    {
        Vector3 relativePosition = exit.position - transform.position;
        transform.position = previousPiece.exit.position - relativePosition;
    }
}
