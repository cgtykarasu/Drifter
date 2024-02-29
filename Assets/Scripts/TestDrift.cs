using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDrift : MonoBehaviour
{
    public float speed;
    public float driftSpeed;
    public float driftDuration;

    private float driftStartTime;
    private bool isDrifting = false;

    void FixedUpdate()
    {
        // Aracı otomatik olarak ileri hareket ettirin
        GetComponent<Rigidbody>().velocity = transform.forward * speed;

        // Space tuşuna basıldığında drift modunu etkinleştirin
        if (Input.GetKey(KeyCode.Space))
        {
            driftStartTime = 0f;
            isDrifting = true;
        }

        // Drift modunda ise aracı döndürün
        if (isDrifting)
        {
            // Drift süresini kontrol edin
            if (Time.time - driftStartTime > driftDuration)
            {
                isDrifting = false;
            }
            else
            {
                // Aracın dönüş açısını kontrol edin
                if (transform.localEulerAngles.y >= 90f)
                {
                    GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                }
                else
                {
                    GetComponent<Rigidbody>().AddTorque(Vector3.up * driftSpeed * Time.deltaTime);
                }
            }
        }
    }
}