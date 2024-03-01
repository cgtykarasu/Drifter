using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class test : MonoBehaviour
{
    // // public float ileriHiz = 10f; // Arabanın ileri hızı
    // // public float donusHizi = 90f; // Dönüş hızı
    // // public float driftGucu = 5f; // Dirift için kullanılacak kuvvet
    // //
    // // private Rigidbody rb;
    // // private bool sagaDonuyor = false;
    // //
    // // private float direction = 1;
    // // private float zRotation = 0;   // zRotation initialized to 0 instead of 360
    // // public float speed = 1000;
    // //
    // // public GameObject car;
    // //
    // //
    // // void Start()
    // // {
    // //     rb = GetComponent<Rigidbody>();
    // //     
    // //     // Aracın rotasyonunu sıfırla
    // //     transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    // //     
    // //     
    // // }
    // //
    // // void Update()
    // // {
    // //     // Arabayı ileri hareket ettirme
    // //     rb.velocity = transform.forward * ileriHiz;
    // //     
    // //     if (Input.GetKey(KeyCode.Space))
    // //     {
    // //         // sagaDonuyor = true;
    // //         // StartCoroutine(SagaDon());
    // //         // StartCoroutine(YaySeklindeDon(0.1f, donusHizi));
    // //         
    // //         transform.RotateAround(car.transform.position, Vector3.up, 180 * Time.deltaTime);
    // //
    // //     }
    // // }
    // //
    // // IEnumerator SagaDon()
    // // {
    // //     float baslangicAci = transform.rotation.eulerAngles.y;
    // //     float hedefAci = baslangicAci + 90f;
    // //
    // //     
    // //     while (transform.rotation.eulerAngles.y < 90 && sagaDonuyor)
    // //     {
    // //         float donusMiktari = donusHizi * Time.deltaTime;
    // //         transform.Rotate(Vector3.up * donusMiktari);
    // //         yield return null;
    // //     }
    // //
    // //     // Düzeltme yaparak tam 90 dereceye dönüşü sağlayın
    // //     transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, hedefAci, transform.rotation.eulerAngles.z);
    // //
    // //     sagaDonuyor = false;
    // // }
    // //
    // // IEnumerator YaySeklindeDon(float donmeSuresi, float donmeHizi)
    // // {
    // //     float elapsedTime = 0f;
    // //     float baslangicAci = transform.rotation.eulerAngles.y;
    // //     float hedefAci = baslangicAci + 45f;
    // //
    // //     while (elapsedTime < donmeSuresi)
    // //     {
    // //         float donmeMiktari = donmeHizi * Time.deltaTime;
    // //         transform.Rotate(Vector3.up * donmeMiktari);
    // //         elapsedTime += Time.deltaTime;
    // //         yield return null;
    // //     }
    // //
    // //     // 45 derece dönme tamamlandıktan sonra dönüş hızını sıfırla
    // //     rb.angularVelocity = Vector3.zero;
    // // }
    // //
    // // void FixedUpdate()
    // // {
    // //     // // Saga drift
    // //     // if (Input.GetKey(KeyCode.Space) && Mathf.Abs(rb.angularVelocity.y) < donusHizi)
    // //     // {
    // //     //     rb.AddRelativeForce(Vector3.right * driftGucu, ForceMode.Force);
    // //     //     transform.Rotate(Vector3.up * donusHizi * Time.fixedDeltaTime);
    // //     // }
    // //     //
    // //     // // Sola drift
    // //     // if (!Input.GetKey(KeyCode.Space) && Mathf.Abs(rb.angularVelocity.y) < donusHizi)
    // //     // {
    // //     //     rb.AddRelativeForce(Vector3.left * driftGucu, ForceMode.Force);
    // //     //     transform.Rotate(Vector3.up * -donusHizi * Time.fixedDeltaTime);
    // //     // }
    // //
    // //     // if (Input.GetKey(KeyCode.Space))
    // //     // {
    // //     //     // Dirft efekti için bir kuvvet uygula
    // //     //     rb.AddRelativeForce(Vector3.right * driftGucu, ForceMode.Force);
    // //     //
    // //     //     // Sağa dönüş yap
    // //     //     transform.Rotate(Vector3.up * donusHizi * Time.fixedDeltaTime);
    // //     // }
    // //
    // // }
    //
    //     // movement speed
    // public float MoveSpeed = 20f;
    //
    // // turn speed
    // // public float turnSpeed = 90f;
    //
    // // drift factor
    // // public float driftFactor = .95f;
    //
    // //breaking status
    // // public bool isBraking = false;
    //
    // //breakingforce
    // // public float brakeForce = 0.985f;
    //
    // // private bool _allowTurning = true;
    //
    // private bool _isGrounded = true;
    //
    //
    // private Rigidbody _rb;
    //
    // void Awake()
    // {
    //     // rigidbody component
    //     _rb = GetComponent<Rigidbody>();
    //     
    //     float reduceCenterMassY = -0.5f;
    //     _rb.centerOfMass = new Vector3(_rb.centerOfMass.x, reduceCenterMassY , _rb.centerOfMass.z);
    //
    //     // center of mass
    //     //rb.centerOfMass = new Vector3(0, -0.5f, 0);
    //     // rb.AddForce(transform.forward * moveSpeed, ForceMode.VelocityChange);
    //
    //     // // Eğer araba başlangıçta sağa dönükse
    //     // if (transform.rotation.eulerAngles.y == 0f && transform.rotation.eulerAngles.y != 90f)
    //     // {
    //     //     // Sadece ileri gitmesini sağla
    //     //     _allowTurning = true;
    //     // }
    // }
    //
    // void Update()
    // {
    // }
    //
    // // bool rotating;
    // // IEnumerator RotateMe(Vector3 byAngles, float inTime)
    // // {
    // //     var fromAngle = transform.rotation;
    // //     var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
    // //     for (var t = 0f; t <= 1; t += Time.deltaTime / inTime)
    // //     {
    // //         transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
    // //       
    // //         yield return null;
    // //     }
    // //
    // //     transform.rotation = toAngle;
    // //     rotating = false;
    // // }
    //
    // IEnumerator Rotate(Vector3 axis, float angle, float duration = 0.4f)
    // {
    //     Quaternion from = transform.rotation;
    //     Quaternion to = transform.rotation * Quaternion.Euler(axis * angle);
    //
    //     float elapsed = 0.2f;
    //     while (elapsed < duration)
    //     {
    //         //transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
    //         _rb.rotation = Quaternion.Slerp(from, to, elapsed / duration);
    //         elapsed += Time.deltaTime;
    //         
    //         yield return null;
    //     }
    //
    //     transform.rotation = to;
    // }
    //
    //
    // void FixedUpdate()
    // {
    //     if (!_isGrounded)
    //     {
    //         transform.Translate(Vector3.forward * Time.deltaTime);
    //         return;
    //     }
    //     // // get vertical input (A and D keys)
    //     // float moveVertical = Mathf.Clamp(Input.GetAxis("Vertical"), 0.5f, 1);
    //     // // get horizontal input (W and S keys)
    //     // float moveHorizontal = Input.GetAxis("Horizontal");
    //     //
    //     // // create movement vector (forward direction)
    //     // Vector3 moveDirection = transform.forward * (moveVertical * moveSpeed);
    //     //
    //     // // apply force to the car
    //     // // rb.AddForce(moveDirection * Time.deltaTime, ForceMode.Acceleration);
    //     // rb.AddForce(moveDirection * Time.deltaTime, ForceMode.Force);
    //     //
    //     //
    //     // // if car speed is greater than 2
    //     // if (rb.velocity.magnitude > 2)
    //     // {
    //     //     // rotation amount
    //     //     float turn = moveHorizontal * turnSpeed * driftFactor * Time.fixedDeltaTime;
    //     //     // create rotation quaternion
    //     //     Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
    //     //     // update rotation
    //     //     rb.MoveRotation(rb.rotation * turnRotation);
    //     // }
    //     //
    //     // // Debug.Log(rb.velocity.magnitude);
    //     //
    //     // if (Input.GetKey(KeyCode.Space))
    //     // {
    //     //     isBraking = true;
    //     //     rb.velocity *= brakeForce;
    //     // }
    //     // else
    //     // {
    //     //     isBraking = false;
    //     // }
    //
    //     transform.Translate(Vector3.forward * (MoveSpeed * Time.deltaTime));
    //     _rb.MovePosition(_rb.position + transform.forward * (MoveSpeed * Time.deltaTime));
    //     // Vector3 moveDirection = transform.forward * MoveSpeed;
    //     // if (_rb.velocity.magnitude < MoveSpeed)
    //     // {
    //     //     _rb.AddForce(moveDirection * Time.deltaTime, ForceMode.VelocityChange);
    //     // }
    //     
    //     //
    //     // if( Input.GetKeyDown(KeyCode.Space) )
    //     // {
    //     //     StartCoroutine(Rotate(Vector3.up, 90, 0.2f));
    //     // }
    //     // if( Input.GetKeyUp(KeyCode.Space) )
    //     // {
    //     //     StartCoroutine(Rotate(Vector3.up, -90, 0.2f));
    //     // }
    //     // // if (_isTurningRight)
    //     // // {
    //     // //     StartCoroutine(Rotate(Vector3.up, 90, 0.5f));
    //     // // }
    //     // // else if (!_isTurningRight)
    //     // // {
    //     // //     StartCoroutine(Rotate(Vector3.up, -90, 0.5f));
    //     // // }
    //
    //     // --------------------------------
    //
    //
    //     // if (Input.GetKeyDown("e") && !rotating)
    //     // {
    //     //     rotating = true;
    //     //     StartCoroutine(RotateMe(Vector3.up * 90, 0.2f));
    //     // }
    //     // if (Input.GetKeyDown("q") && !rotating)
    //     // {
    //     //     rotating = true;
    //     //     StartCoroutine(RotateMe(Vector3.up * -90, 0.2f));
    //     // }
    //
    //     // Debug.Log(transform.rotation.eulerAngles.y);
    //
    //     if (Input.GetKey(KeyCode.Space) && (transform.rotation.eulerAngles.y < 360f && transform.rotation.eulerAngles.y > 300f ||
    //                                         transform.rotation.eulerAngles.y < 5f && transform.rotation.eulerAngles.y > -5f))
    //     {
    //         StartCoroutine(Rotate(Vector3.up, 90));
    //         // _rb.rotation = Quaternion.Euler(0, -180, 0);
    //
    //
    //             // // rotation amount
    //             // float turn = MoveSpeed * Time.fixedDeltaTime;
    //             // // create rotation quaternion
    //             // Quaternion turnRotation = Quaternion.Euler(0f, 90, 0f);
    //             // // update rotation
    //             // _rb.MoveRotation(_rb.rotation * turnRotation);
    //
    //
    //             // _rb.AddForce(new Vector3(200,0,0), ForceMode.Force);
    //
    //
    //         // if (!rotating)
    //         // {
    //         //     StartCoroutine(RotateMe(Vector3.up * 90, 0.2f));
    //         //     rotating = true;
    //         // }
    //         // if (rotating)
    //         // {
    //         //     StartCoroutine(RotateMe(Vector3.up * -90, 0.2f));
    //         //     rotating = false;
    //         // }
    //         //
    //         // _allowTurning = false;
    //
    //         // StartCoroutine(RotateMe(Vector3.up * 90, 0.1f));
    //
    //         // Debug.Log(transform.rotation.eulerAngles.y);
    //         //
    //         // if (transform.rotation.eulerAngles.y < 360f && transform.rotation.eulerAngles.y > 350f || transform.rotation.eulerAngles.y < 0.5f && transform.rotation.eulerAngles.y > -0.5f)
    //         // {
    //         //     StartCoroutine(Rotate(Vector3.up, 90, 0.2f));
    //         // }
    //
    //         // else if (transform.rotation.eulerAngles.y == 90f && transform.rotation.eulerAngles.y != 0f)
    //         // {
    //         //     StartCoroutine(Rotate(Vector3.up, -90, 0.2f));
    //         // }
    //     }
    //
    //     else if (!Input.GetKey(KeyCode.Space) && (transform.rotation.eulerAngles.y < 100f && transform.rotation.eulerAngles.y > 80f))
    //     {
    //         StartCoroutine(Rotate(Vector3.up, -90));
    //         // _rb.rotation = Quaternion.Euler(0, -180, 0);
    //
    //         // if (_rb.velocity.magnitude > 2)
    //         // {
    //         //     // rotation amount
    //         //     float turn = MoveSpeed * 100f * .95f * Time.fixedDeltaTime;
    //         //     // create rotation quaternion
    //         //     Quaternion turnRotation = Quaternion.Euler(0f, -90, 0f);
    //         //     // update rotation
    //         //     _rb.MoveRotation(_rb.rotation * turnRotation);
    //         // }
    //
    //
    //         // _rb.AddForce(new Vector3(200,0,0), ForceMode.Force);
    //
    //     }
    //     // {
    //     //     if (transform.rotation.eulerAngles.y < 91f && transform.rotation.eulerAngles.y > 89f)
    //     //     {
    //     //         StartCoroutine(Rotate(Vector3.up, -90, 0.2f));
    //     //     }
    //     // }
    // }
    //
    // void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("Platform"))
    //     {
    //         Debug.Log("Çıktı");
    //         _rb.useGravity = true;
    //         Invoke("AktifEt", 0.25f);
    //         //rb.velocity=Vector3.down
    //     }
    // }
    //
    // void AktifEt()
    // {
    //     _isGrounded = false;
    // }
    // [SerializeField] float _rotationSpeed = 1.0f;

    // speed of the car
    [SerializeField] private float _speed = 15f;
    // rotation speed
    [SerializeField] private float _dt = 5.5f;

    // target rotation
    private Quaternion targetRotation;
    // back rotation
    private Quaternion backRotation;

    // grounded status
    public bool grounded = false;
    // grounded check distance
    public float groundedCheckDistance;
    // buffer check distance
    private float _bufferCheckDistance = 0.005f;

    // rigidbody component
    private Rigidbody _rb;
    // box collider component
    private BoxCollider _boxCollider;

    // float _dt = 0.5f;
    // float _speed = 30f;
    // Quaternion _from;
    // Quaternion _to;
    
    private void Awake()
    {
        // rigidbody component
        _rb = GetComponent<Rigidbody>();
        // box collider component
        _boxCollider = GetComponent<BoxCollider>();
        // center of mass
        _rb.centerOfMass = new Vector3(_rb.centerOfMass.x, -.5f, _rb.centerOfMass.z);
    }

    private void Start()
    {
        // target rotation
        targetRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 90, 0));
        // back rotation
        backRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, 0));

        // _from = Quaternion.identity;
        // _to = transform.rotation * Quaternion.Lerp(_from, _to, _dt * _speed);
        // float _angle = Quaternion.Angle(_from, _to);
    }

    private void Update()
    {
        // get the transform of the box
        Transform boxTransform = transform;

        // get the size of the box
        Vector3 boxSize = boxTransform.localScale;

        // get the center of the box
        Vector3 boxCenter = boxTransform.position;

        // Calculate the edge point of the box (for example, half width on the x-axis, half width on the y-axis, half width on the z-axis)
        Vector3 leftFront = boxCenter + new Vector3(boxSize.x/2 + .275f, -boxSize.y/2 + .2f, boxSize.z/2 + .35f);
        Vector3 rightFront = boxCenter + new Vector3(-boxSize.x/2 -.125f, -boxSize.y/2 + .2f, boxSize.z/2 + .35f);
        Vector3 leftRear = boxCenter + new Vector3(boxSize.x/2 + .275f, -boxSize.y/2 + .2f, -boxSize.z/2 - .35f);
        Vector3 rightRear = boxCenter + new Vector3(-boxSize.x/2 -.125f, -boxSize.y/2 + .2f, -boxSize.z/2 - .35f);
        
        // Find a target point for the raycast operation (for example, in a forward direction)
        Vector3 raycastDirection = boxTransform.forward;
        
        // Raycast için başlangıç noktasını belirle (örneğin, küpün kenar noktası)
        // Vector3 raycastOrigin = boxEdge;
        
        // Raycast yap
        // RaycastHit hitInfo;
        // if (Physics.Raycast(raycastOrigin, raycastDirection, out hitInfo))
        // {
        //     // Eğer bir çarpışma varsa, çarpışma bilgisini işle
        //     Debug.Log("Hit object: " + hitInfo.collider.gameObject.name);
        // }
        
        _rb.MovePosition(_rb.position + transform.forward * (_speed * Time.deltaTime));

        groundedCheckDistance = _boxCollider.bounds.extents.y + _bufferCheckDistance;
        grounded = Physics.Raycast(leftFront, Vector3.down, groundedCheckDistance) &&
                   Physics.Raycast(rightFront, Vector3.down, groundedCheckDistance) &&
                   Physics.Raycast(leftRear, Vector3.down, groundedCheckDistance) &&
                   Physics.Raycast(rightRear, Vector3.down, groundedCheckDistance);
        
        // grounded = Physics.Raycast(transform.position, Vector3.down, groundedCheckDistance);

        Debug.DrawRay(leftFront, Vector3.up * 2, Color.cyan);
        Debug.DrawRay(rightFront, Vector3.up * 2, Color.magenta);
        Debug.DrawRay(leftRear, Vector3.up * 2, Color.yellow);
        Debug.DrawRay(rightRear, Vector3.up * 2, Color.blue);
        
        Debug.Log("leftFront : " + Physics.Raycast(leftFront, Vector3.down, groundedCheckDistance));
        Debug.Log("rightFront : " + Physics.Raycast(rightFront, Vector3.down, groundedCheckDistance));
        Debug.Log("leftRear : " + Physics.Raycast(leftRear, Vector3.down, groundedCheckDistance));
        Debug.Log("rightRear : " + Physics.Raycast(rightRear, Vector3.down, groundedCheckDistance));
        // Debug.Log("Transform pos : " + Physics.Raycast(transform.position, Vector3.down, groundedCheckDistance));
        Debug.Log("GROUNDED : " + grounded);
        
        switch (grounded)
        {
            case true:
                Debug.DrawRay(transform.position, Vector3.up * 10, Color.green);
                // Debug.Log("ZEMİNDE");
                break;
            case false:
                Debug.DrawRay(transform.position, Vector3.up * 10, Color.red);
                // Debug.Log("ZEMİNDE DEĞİL");
                // transform.up = Vector3.zero;
                // _rb.AddTorque(Vector3.right * 1000f, ForceMode.Impulse);
                // _rb.AddExplosionForce(500f, transform.position, 10f, 3.0f, ForceMode.Impulse);

                // Invoke("AktifEt", 0.025f);
                break;
        }
    }

    private void AktifEt()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _dt * Time.fixedDeltaTime);
        }
        else if (!Input.GetKey(KeyCode.Space))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, backRotation, _dt * Time.fixedDeltaTime);
        }
        //transform.rotation = Quaternion.Lerp(_from, _to, _dt * _speed);


        // else if (!Input.GetKey(KeyCode.Space))
        // {
        //     transform.rotation = Quaternion.Lerp(transform.rotation, backRotation, _dt * Time.deltaTime);
        // }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            Debug.Log("Çıktı");
            _rb.useGravity = true;
            // Invoke("AktifEt", 0.25f);
            //rb.velocity=Vector3.down
        }
    }
}