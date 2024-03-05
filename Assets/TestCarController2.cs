using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCarController2 : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 100f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * moveVertical * speed * Time.deltaTime;
        rb.AddForce(movement);

        // float turn = moveHorizontal * turnSpeed * Time.deltaTime;
        // Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        // rb.MoveRotation(rb.rotation * turnRotation);
        
        if (IsGrounded())
        {
            float turn = moveHorizontal * turnSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
        
        Debug.DrawRay(transform.position, -Vector3.up * 4.5f, Color.blue);
        
        
    }
    
    void Update()
    {
        if (!IsGrounded())
        {
            rb.AddForce(Vector3.down * 10f);
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 4.5f);
    }
}