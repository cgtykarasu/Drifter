using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float ileriHiz = 10f; // Arabanın ileri hızı
    public float donusHizi = 90f; // Dönüş hızı
    public float driftGucu = 5f; // Dirift için kullanılacak kuvvet

    private Rigidbody rb;
    private bool sagaDonuyor = false;
    
    private float direction = 1;
    private float zRotation = 0;   // zRotation initialized to 0 instead of 360
    public float speed = 1000;
    
    public GameObject car;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // Aracın rotasyonunu sıfırla
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        
        
    }

    void Update()
    {
        // Arabayı ileri hareket ettirme
        rb.velocity = transform.forward * ileriHiz;
        
        if (Input.GetKey(KeyCode.Space))
        {
            // sagaDonuyor = true;
            // StartCoroutine(SagaDon());
            // StartCoroutine(YaySeklindeDon(0.1f, donusHizi));
            
            transform.RotateAround(car.transform.position, Vector3.up, 180 * Time.deltaTime);

        }
    }

    IEnumerator SagaDon()
    {
        float baslangicAci = transform.rotation.eulerAngles.y;
        float hedefAci = baslangicAci + 90f;

        
        while (transform.rotation.eulerAngles.y < 90 && sagaDonuyor)
        {
            float donusMiktari = donusHizi * Time.deltaTime;
            transform.Rotate(Vector3.up * donusMiktari);
            yield return null;
        }

        // Düzeltme yaparak tam 90 dereceye dönüşü sağlayın
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, hedefAci, transform.rotation.eulerAngles.z);

        sagaDonuyor = false;
    }
    
    IEnumerator YaySeklindeDon(float donmeSuresi, float donmeHizi)
    {
        float elapsedTime = 0f;
        float baslangicAci = transform.rotation.eulerAngles.y;
        float hedefAci = baslangicAci + 45f;

        while (elapsedTime < donmeSuresi)
        {
            float donmeMiktari = donmeHizi * Time.deltaTime;
            transform.Rotate(Vector3.up * donmeMiktari);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 45 derece dönme tamamlandıktan sonra dönüş hızını sıfırla
        rb.angularVelocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        // // Saga drift
        // if (Input.GetKey(KeyCode.Space) && Mathf.Abs(rb.angularVelocity.y) < donusHizi)
        // {
        //     rb.AddRelativeForce(Vector3.right * driftGucu, ForceMode.Force);
        //     transform.Rotate(Vector3.up * donusHizi * Time.fixedDeltaTime);
        // }
        //
        // // Sola drift
        // if (!Input.GetKey(KeyCode.Space) && Mathf.Abs(rb.angularVelocity.y) < donusHizi)
        // {
        //     rb.AddRelativeForce(Vector3.left * driftGucu, ForceMode.Force);
        //     transform.Rotate(Vector3.up * -donusHizi * Time.fixedDeltaTime);
        // }

        // if (Input.GetKey(KeyCode.Space))
        // {
        //     // Dirft efekti için bir kuvvet uygula
        //     rb.AddRelativeForce(Vector3.right * driftGucu, ForceMode.Force);
        //
        //     // Sağa dönüş yap
        //     transform.Rotate(Vector3.up * donusHizi * Time.fixedDeltaTime);
        // }

    }
}
