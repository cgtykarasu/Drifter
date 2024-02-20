using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // movement speed
    public float moveSpeed = 30f;
    // turn speed
    public float turnSpeed = 100f;

    private Rigidbody rb;

    void Start()
    {
        // rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // get vertical input (W and S keys)
        float moveVertical = Input.GetAxis("Vertical");

        // create movement vector (forward direction)
        Vector3 movement = transform.forward * moveVertical;
        
        // update position
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // dont rotate if there is no vertical input
        if (moveVertical != 0f)
        {
            // rotation amount
            float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.fixedDeltaTime;
            
            // create rotation quaternion
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            
            // update rotation
            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }
}