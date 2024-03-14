using System;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class CarController : MonoBehaviour
{
    Rigidbody _rb;
    BoxCollider _boxCollider;
    GameController _gameController;
    Quaternion startingRotation, targetRotation;
    bool _driftCheck;
    float _bufferCheckDistance = 3f;

    public GameObject CarBody;
    public Transform[] wheels = new Transform[4];
    public TrailRenderer[] trails = new TrailRenderer[4];
    public AudioSource carEngine, carDrift;
    public float speed = 35f, turnSpeed = 200f, groundedCheckDistance;
    public bool grounded;
    bool _isDrifting;

    readonly float[] _rotations = { -500f, -500f, 500f, 500f };

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.centerOfMass = new Vector3(_rb.centerOfMass.x, -0.5f, _rb.centerOfMass.z);
        startingRotation = transform.rotation;
        targetRotation = Quaternion.Euler(0f, 90f, 0f);
        _gameController = FindObjectOfType<GameController>();
        _boxCollider = GetComponent<BoxCollider>();
        carEngine.Play();
    }

    void FixedUpdate()
    {
        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].Rotate(0, 0, _rotations[i] * Time.deltaTime);
        }
        
        Vector3 boxCenter = transform.position;
        Vector3 boxSize = transform.localScale;
        Vector3[] corners = new Vector3[4]
        {
            boxCenter + new Vector3(boxSize.x / 2, -boxSize.y / 2, boxSize.z / 2),
            boxCenter + new Vector3(-boxSize.x / 2, -boxSize.y / 2, boxSize.z / 2),
            boxCenter + new Vector3(boxSize.x / 2, -boxSize.y / 2, -boxSize.z / 2),
            boxCenter + new Vector3(-boxSize.x / 2, -boxSize.y / 2, -boxSize.z / 2)
        };

        groundedCheckDistance = _boxCollider.bounds.extents.y + _bufferCheckDistance;
        grounded = true;
        foreach (var corner in corners)
        {
            grounded |= Physics.Raycast(corner, -Vector3.up, groundedCheckDistance);
            Debug.DrawRay(corner, -Vector3.up, grounded ? Color.green : Color.red);
        }
        
        grounded = Physics.Raycast(corners[0], -Vector3.up, groundedCheckDistance) ||
                   Physics.Raycast(corners[1], -Vector3.up, groundedCheckDistance) ||
                   Physics.Raycast(corners[2], -Vector3.up, groundedCheckDistance) ||
                   Physics.Raycast(corners[3], -Vector3.up, groundedCheckDistance);

        if (grounded)
        {
            _rb.AddForce(transform.forward * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
            _rb.MoveRotation(Quaternion.RotateTowards(_rb.rotation, Input.GetKey(KeyCode.Space) ? targetRotation : startingRotation, turnSpeed * Time.fixedDeltaTime));
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            _rb.AddForce(Vector3.down * 10f);
            GameOverAsync().Forget();
        }
        
        _isDrifting = CarBody.transform.localRotation.y * 100 > 15 && CarBody.transform.localRotation.y * 100 < 70;
        foreach (var trail in trails)
        {
            trail.emitting = _isDrifting;
        }
        if (_isDrifting && !_driftCheck)
        {
            _driftCheck = true;
            carDrift.Play();
        }
        else
        {
            _driftCheck = false;
        }
    }

    async UniTaskVoid GameOverAsync()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(.25f));
        _gameController.GameOver();
        gameObject.SetActive(false);
        carEngine.Stop();
    }
}