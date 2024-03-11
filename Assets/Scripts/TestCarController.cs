using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCarController : MonoBehaviour
{
    Rigidbody _rb;
    public GameObject CarBody;

    public Transform Wheel1;
    public Transform Wheel2;
    public Transform Wheel3;
    public Transform Wheel4;

    public Transform Right;
    public Transform Left;
    public Transform Straight;

    public TrailRenderer Trail1;
    public TrailRenderer Trail2;
    public TrailRenderer Trail3;
    public TrailRenderer Trail4;

    public AudioSource CarEngine;
    public AudioSource CarDrift;
    public bool DriftCheck;
    
    public SpawnController spawnController;

    public float MoveSpeed = 50f;
    public float TurnSpeed = 0.8f;

    private void Start()
    {
        // _rb = gameObject.GetComponent<Rigidbody>();
        _rb = GetComponent<Rigidbody>();
        float reduceCenterMassY = -0.5f;
        _rb.centerOfMass = new Vector3(_rb.centerOfMass.x, reduceCenterMassY , _rb.centerOfMass.z);
        CarEngine.Play();
    }

    private void Update()
    {
        // _rb.velocity += transform.forward * 150 * Time.deltaTime;
        
        Wheel1.Rotate(0, 0, -500 * Time.deltaTime);
        Wheel2.Rotate(0, 0, -500 * Time.deltaTime);
        Wheel3.Rotate(0, 0, 500 * Time.deltaTime);
        Wheel4.Rotate(0, 0, 500 * Time.deltaTime);
        
        MoveSpeed += Time.deltaTime * 10f;
        MoveSpeed = Mathf.Min (MoveSpeed, TurnSpeed);
        _rb.AddRelativeForce(0,0,MoveSpeed);
        
        // if (Input.GetKey("w"))
        // {
        //     RB.velocity += transform.forward * 150 * Time.deltaTime;
        //
        //     Wheel1.Rotate(0, 0, -500 * Time.deltaTime);
        //     Wheel2.Rotate(0, 0, -500 * Time.deltaTime);
        //     Wheel3.Rotate(0, 0, 500 * Time.deltaTime);
        //     Wheel4.Rotate(0, 0, 500 * Time.deltaTime);
        //
        //     if(CarEngine.isPlaying == false)
        //     {
        //         CarEngine.Play();
        //     }
        // }
        // else
        // {
        //     CarEngine.Stop();
        // }
        
        // if (Input.GetKey("s"))
        // {
        //     RB.velocity -= transform.forward * 80 * Time.deltaTime;
        //
        //     Wheel1.Rotate(0, 0, 500 * Time.deltaTime);
        //     Wheel2.Rotate(0, 0, 500 * Time.deltaTime);
        //     Wheel3.Rotate(0, 0, -500 * Time.deltaTime);
        //     Wheel4.Rotate(0, 0, -500 * Time.deltaTime);
        // }
        
        if(Input.GetKey("a"))
        {
            // transform.Rotate(0, -30 * Time.deltaTime, 0);
            // CarBody.transform.rotation = Quaternion.Lerp(CarBody.transform.rotation, Left.rotation, 4 * Time.deltaTime);
            // _rb.velocity += CarBody.transform.forward * 120 * Time.deltaTime;
            // _rb.velocity -= transform.forward * 110 * Time.deltaTime;
            _rb.rotation = _rb.rotation * Quaternion.Euler (Vector3.up * 5f);
        
        }
        
        if(Input.GetKey("d"))
        {
            transform.Rotate(0, 30 * Time.deltaTime, 0);
            CarBody.transform.rotation = Quaternion.Lerp(CarBody.transform.rotation, Right.rotation, 4 * Time.deltaTime);
            _rb.velocity += CarBody.transform.forward * 120 * Time.deltaTime;
            _rb.velocity -= transform.forward * 110 * Time.deltaTime;
        }
        
        if(!Input.GetKey("d") && !Input.GetKey("a"))
        {
            CarBody.transform.rotation = Quaternion.Lerp(CarBody.transform.rotation, Straight.rotation, 4 * Time.deltaTime);
        }
        
        if(CarBody.transform.localRotation.y * 100 > 15 || CarBody.transform.localRotation.y * 100 < -15)
        {
            Trail1.emitting = true;
            Trail2.emitting = true;
            Trail3.emitting = true;
            Trail4.emitting = true;
        
            if(DriftCheck == false)
            {
                DriftCheck = true;
                CarDrift.Play();
            }
        }
        else
        {
            DriftCheck = false;
        
            Trail1.emitting = false;
            Trail2.emitting = false;
            Trail3.emitting = false;
            Trail4.emitting = false;
        }
    }

    void FixedUpdate()
    {
        float vert = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");
        
        if (vert > 0)
        {
            _rb.AddRelativeForce(Vector3.forward * vert * MoveSpeed, ForceMode.Acceleration);
        }

        if (hor != 0)
        {
            _rb.AddRelativeTorque(Vector3.up * hor * TurnSpeed, ForceMode.VelocityChange);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        spawnController.SpawnTriggerEntered();
    }
}
