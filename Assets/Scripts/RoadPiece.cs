using UnityEngine;

public class RoadPiece : MonoBehaviour
{
    public Transform exit;

    public void Place(RoadPiece previousPiece)
    {
        transform.position = previousPiece.exit.position - (exit.position - transform.position);
    }
}
