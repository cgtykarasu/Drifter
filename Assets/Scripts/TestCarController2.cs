using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCarController2 : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 100f;

    private Rigidbody rb;
    Quaternion startingRotation;
    Quaternion targetRotation;
    
    GameController _gameController;
    
    // -------------
    
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
    
    //------
    
    // grounded status
    public bool grounded = false;
    // grounded check distance
    public float groundedCheckDistance;
    // buffer check distance
    private float _bufferCheckDistance = 0.005f;
    
    // box collider component
    private BoxCollider _boxCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        float reduceCenterMassY = -0.5f;
        rb.centerOfMass = new Vector3(rb.centerOfMass.x, reduceCenterMassY, rb.centerOfMass.z);
        startingRotation = transform.rotation;
        targetRotation = Quaternion.Euler(0f, 90f, 0f);
        _gameController = FindObjectOfType<GameController>();
        _boxCollider = GetComponent<BoxCollider>();
        CarEngine.Play();
    }

    void FixedUpdate()
    {
        // float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        // float turn = moveHorizontal * turnSpeed * Time.deltaTime;
        
        // Vector3 movement = transform.forward * speed * Time.fixedDeltaTime;
        // rb.AddForce(movement, ForceMode.VelocityChange);

        if (IsGrounded())
        {
            Vector3 movement = transform.forward * speed * Time.fixedDeltaTime;
            rb.AddForce(movement, ForceMode.VelocityChange);
        
            // Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            // rb.MoveRotation(rb.rotation * turnRotation);
        
            if (Input.GetKey(KeyCode.Space))
            {
                // transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
                // transform.rotation = Quaternion.Euler(0f, Mathf.Clamp(transform.rotation.eulerAngles.y, 0f, 90f), 0f);
                rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime));
            }
        
            else
            {
                // transform.rotation = Quaternion.RotateTowards(transform.rotation, başlangıçRotasyonu, turnSpeed * Time.deltaTime);
                rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, startingRotation, turnSpeed * Time.fixedDeltaTime));
            
            }
        }

        // Debug.DrawRay(transform.position, -Vector3.up * 4.5f, Color.blue);
        // Debug.Log("RAYCAST STATUS : " + Physics.Raycast(transform.position, -Vector3.up, 4.5f));
    }

    void Update()
    {
        Wheel1.Rotate(0, 0, -500 * Time.deltaTime);
        Wheel2.Rotate(0, 0, -500 * Time.deltaTime);
        Wheel3.Rotate(0, 0, 500 * Time.deltaTime);
        Wheel4.Rotate(0, 0, 500 * Time.deltaTime);
        
        if (!IsGrounded())
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            rb.AddForce(Vector3.down * 10f);
            // _gameController.GameOver();
            StartCoroutine("GameOver");
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
        
        // get the transform of the box
        Transform boxTransform = transform;

        // get the size of the box
        Vector3 boxSize = boxTransform.localScale;

        // get the center of the box
        Vector3 boxCenter = boxTransform.position;
        
        Vector3 leftFront = boxCenter + new Vector3(boxSize.x/2 + .275f, -boxSize.y/2 + .2f, boxSize.z/2 + .35f);
        Vector3 rightFront = boxCenter + new Vector3(-boxSize.x/2 -.125f, -boxSize.y/2 + .2f, boxSize.z/2 + .35f);
        Vector3 leftRear = boxCenter + new Vector3(boxSize.x/2 + .275f, -boxSize.y/2 + .2f, -boxSize.z/2 - .35f);
        Vector3 rightRear = boxCenter + new Vector3(-boxSize.x/2 -.125f, -boxSize.y/2 + .2f, -boxSize.z/2 - .35f);
        
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

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1f);
        _gameController.GameOver();
        gameObject.SetActive(false);
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 4.5f);
        
        
    }
}