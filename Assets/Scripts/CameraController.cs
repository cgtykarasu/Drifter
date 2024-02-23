using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Ana karakterin transform bileşeni

    public Vector3 offset = new Vector3(-20, 5, -1); // Kameranın ana karakterin konumuna göre konumunu ayarlamak için kullanılacak vektör
    
    void Update()
    {
        // Kameranın konumunu ana karakterin konumuna ayarla
        transform.position = target.position + offset;

        // Kameranın rotasyonunu sabit tut
        // transform.rotation = Quaternion.Euler(45f, 0f, 0f); // Örneğin kamera 45 derece eğik olacak şekilde ayarlandı
    }
}
