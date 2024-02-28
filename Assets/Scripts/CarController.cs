using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // movement speed
    [SerializeField] float MoveSpeed = 2f;

    // private bool _isGrounded = true;
    public bool grounded = false;
    public float groundedCheckDistance;
    float _bufferCheckDistance = 0.05f;

    private Rigidbody _rb;
    private BoxCollider _boxCollider;

    void Awake()
    {
        // rigidbody component
        _rb = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
        
        _rb.centerOfMass = new Vector3(_rb.centerOfMass.x, -.5f , _rb.centerOfMass.z);
    }

    private void Update()
    {
        groundedCheckDistance = _boxCollider.bounds.extents.y + _bufferCheckDistance;
        grounded = Physics.Raycast(transform.position, Vector3.down, groundedCheckDistance);
        if (grounded)
        {
            Debug.DrawRay(transform.position, Vector3.up * 10, Color.blue);
            Debug.Log("ZEMİNDE");
        }
    }

    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t <= 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            
          
            yield return null;
        }
    
        transform.rotation = toAngle;
    }
    
    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + transform.forward * (MoveSpeed * Time.deltaTime));
        
        float driftRotationAmount = 90f;

        Debug.Log(transform.rotation.eulerAngles.z);

        if (Input.GetKey(KeyCode.Space) &&
            (transform.rotation.eulerAngles.y < 360f && transform.rotation.eulerAngles.y > 340f ||
             transform.rotation.eulerAngles.y < 1.5f && transform.rotation.eulerAngles.y > -1.5f))
        {
            StartCoroutine(RotateMe(Vector3.up * driftRotationAmount, .001f));
             _rb.AddForce(transform.forward * MoveSpeed * 175);
            // transform.rotation *= Quaternion.AngleAxis(90f, Vector3.up);

        }
        else if (!Input.GetKey(KeyCode.Space) && (transform.rotation.eulerAngles.y < 100f && transform.rotation.eulerAngles.y > 80f))
        {
            StartCoroutine(RotateMe(Vector3.up * -90f, .001f));
            _rb.AddForce(transform.forward * MoveSpeed * 175);
            // transform.rotation *= Quaternion.AngleAxis(-90f, Vector3.up);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            Debug.Log("Çıktı");
            _rb.useGravity = true;
            Invoke("AktifEt", 0.25f);
            //rb.velocity=Vector3.down
        }
    }

    // void AktifEt()
    // {
    //     _isGrounded = false;
    // }
}