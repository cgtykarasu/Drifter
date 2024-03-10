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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        float reduceCenterMassY = -0.5f;
        rb.centerOfMass = new Vector3(rb.centerOfMass.x, reduceCenterMassY, rb.centerOfMass.z);
        startingRotation = transform.rotation;
        targetRotation = Quaternion.Euler(0f, 90f, 0f);
        _gameController = FindObjectOfType<GameController>();
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
        if (!IsGrounded())
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            rb.AddForce(Vector3.down * 10f);
            // _gameController.GameOver();
            StartCoroutine("GameOver");
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