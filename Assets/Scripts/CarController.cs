using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // movement speed
    public float moveSpeed = 40f;

    // turn speed
    public float turnSpeed = 90f;

    // drift factor
    public float driftFactor = .95f;

    //breaking status
    public bool isBraking = false;

    //breakingforce
    public float brakeForce = 0.985f;

    private bool _allowTurning = true;

    private bool _isGrounded = true;


    private Rigidbody rb;

    void Start()
    {
        // rigidbody component
        rb = GetComponent<Rigidbody>();

        // center of mass
        rb.centerOfMass = new Vector3(0, -0.5f, 0);
        // rb.AddForce(transform.forward * moveSpeed, ForceMode.VelocityChange);

        // // Eğer araba başlangıçta sağa dönükse
        // if (transform.rotation.eulerAngles.y == 0f && transform.rotation.eulerAngles.y != 90f)
        // {
        //     // Sadece ileri gitmesini sağla
        //     _allowTurning = true;
        // }
    }

    void Update()
    {
    }

    // bool rotating;
    // IEnumerator RotateMe(Vector3 byAngles, float inTime)
    // {
    //     var fromAngle = transform.rotation;
    //     var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
    //     for (var t = 0f; t <= 1; t += Time.deltaTime / inTime)
    //     {
    //         transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
    //       
    //         yield return null;
    //     }
    //
    //     transform.rotation = toAngle;
    //     rotating = false;
    // }

    IEnumerator Rotate(Vector3 axis, float angle, float duration = 0.7f)
    {
        Quaternion from = transform.rotation;
        Quaternion to = transform.rotation;
        to *= Quaternion.Euler(axis * angle);

        float elapsed = 0.1f;
        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = to;
    }


    void FixedUpdate()
    {
        if (!_isGrounded)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            return;
        }
        // // get vertical input (A and D keys)
        // float moveVertical = Mathf.Clamp(Input.GetAxis("Vertical"), 0.5f, 1);
        // // get horizontal input (W and S keys)
        // float moveHorizontal = Input.GetAxis("Horizontal");
        //
        // // create movement vector (forward direction)
        // Vector3 moveDirection = transform.forward * (moveVertical * moveSpeed);
        //
        // // apply force to the car
        // // rb.AddForce(moveDirection * Time.deltaTime, ForceMode.Acceleration);
        // rb.AddForce(moveDirection * Time.deltaTime, ForceMode.Force);
        //
        //
        // // if car speed is greater than 2
        // if (rb.velocity.magnitude > 2)
        // {
        //     // rotation amount
        //     float turn = moveHorizontal * turnSpeed * driftFactor * Time.fixedDeltaTime;
        //     // create rotation quaternion
        //     Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        //     // update rotation
        //     rb.MoveRotation(rb.rotation * turnRotation);
        // }
        //
        // // Debug.Log(rb.velocity.magnitude);
        //
        // if (Input.GetKey(KeyCode.Space))
        // {
        //     isBraking = true;
        //     rb.velocity *= brakeForce;
        // }
        // else
        // {
        //     isBraking = false;
        // }

        transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));
        //
        // if( Input.GetKeyDown(KeyCode.Space) )
        // {
        //     StartCoroutine(Rotate(Vector3.up, 90, 0.2f));
        // }
        // if( Input.GetKeyUp(KeyCode.Space) )
        // {
        //     StartCoroutine(Rotate(Vector3.up, -90, 0.2f));
        // }
        // // if (_isTurningRight)
        // // {
        // //     StartCoroutine(Rotate(Vector3.up, 90, 0.5f));
        // // }
        // // else if (!_isTurningRight)
        // // {
        // //     StartCoroutine(Rotate(Vector3.up, -90, 0.5f));
        // // }

        // --------------------------------


        // if (Input.GetKeyDown("e") && !rotating)
        // {
        //     rotating = true;
        //     StartCoroutine(RotateMe(Vector3.up * 90, 0.2f));
        // }
        // if (Input.GetKeyDown("q") && !rotating)
        // {
        //     rotating = true;
        //     StartCoroutine(RotateMe(Vector3.up * -90, 0.2f));
        // }

        // Debug.Log(transform.rotation.eulerAngles.y);

        if (Input.GetKey(KeyCode.Space) && (transform.rotation.eulerAngles.y < 360f && transform.rotation.eulerAngles.y > 350f ||
                                            transform.rotation.eulerAngles.y < 0.5f && transform.rotation.eulerAngles.y > -0.5f))
        {
            StartCoroutine(Rotate(Vector3.up, 90, 0.2f));

            // if (!rotating)
            // {
            //     StartCoroutine(RotateMe(Vector3.up * 90, 0.2f));
            //     rotating = true;
            // }
            // if (rotating)
            // {
            //     StartCoroutine(RotateMe(Vector3.up * -90, 0.2f));
            //     rotating = false;
            // }
            //
            // _allowTurning = false;

            // StartCoroutine(RotateMe(Vector3.up * 90, 0.1f));

            // Debug.Log(transform.rotation.eulerAngles.y);
            //
            // if (transform.rotation.eulerAngles.y < 360f && transform.rotation.eulerAngles.y > 350f || transform.rotation.eulerAngles.y < 0.5f && transform.rotation.eulerAngles.y > -0.5f)
            // {
            //     StartCoroutine(Rotate(Vector3.up, 90, 0.2f));
            // }

            // else if (transform.rotation.eulerAngles.y == 90f && transform.rotation.eulerAngles.y != 0f)
            // {
            //     StartCoroutine(Rotate(Vector3.up, -90, 0.2f));
            // }
        }

        else if (!Input.GetKey(KeyCode.Space) && (transform.rotation.eulerAngles.y < 91f && transform.rotation.eulerAngles.y > 89f))
        {
            StartCoroutine(Rotate(Vector3.up, -90, 0.2f));
        }
        // {
        //     if (transform.rotation.eulerAngles.y < 91f && transform.rotation.eulerAngles.y > 89f)
        //     {
        //         StartCoroutine(Rotate(Vector3.up, -90, 0.2f));
        //     }
        // }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            Debug.Log("Çıktı");
            rb.useGravity = true;
            Invoke("AktifEt", 0.25f);
            //rb.velocity=Vector3.down
        }
    }

    void AktifEt()
    {
        _isGrounded = false;
    }
}