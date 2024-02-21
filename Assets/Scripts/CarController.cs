using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // movement speed
    public float moveSpeed = 1250f;

    // turn speed
    public float turnSpeed = 100f;

    // drift factor
    public float driftFactor = .95f;

    //breaking status
    public bool isBraking = false;

    //breakingforce
    public float brakeForce = 0.985f;


    private Rigidbody rb;

    void Start()
    {
        // rigidbody component
        rb = GetComponent<Rigidbody>();

        // center of mass
        rb.centerOfMass = new Vector3(0, -0.5f, 0);
    }

    void FixedUpdate()
    {
        // get vertical input (A and D keys)
        float moveVertical = Input.GetAxis("Vertical");
        // get horizontal input (W and S keys)
        float moveHorizontal = Input.GetAxis("Horizontal");

        // create movement vector (forward direction)
        Vector3 moveDirection = transform.forward * (moveVertical * moveSpeed);

        // apply force to the car
        rb.AddForce(moveDirection * Time.deltaTime, ForceMode.Acceleration);

        // if car speed is greater than 2
        if (rb.velocity.magnitude > 2)
        {
            // rotation amount
            float turn = moveHorizontal * turnSpeed * driftFactor * Time.fixedDeltaTime;
            // create rotation quaternion
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            // update rotation
            rb.MoveRotation(rb.rotation * turnRotation);
        }

        // Debug.Log(rb.velocity.magnitude);

        if (Input.GetKey(KeyCode.Space))
        {
            isBraking = true;
            rb.velocity *= brakeForce;
        }
        else
        {
            isBraking = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            Debug.Log("DANGEEEERRRRR");
            rb.useGravity = true;
            //rb.velocity=Vector3.down;
        }
    }
}