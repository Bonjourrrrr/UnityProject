using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private MeshRenderer meshRendererPlayer;
    private Rigidbody rbPlayer;
    public float speed = 1.0f; // Speed of the player
    private Vector3 movement;
    public Transform cameraTransform;
    private int level;

    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        meshRendererPlayer = GetComponent<MeshRenderer>();
        rbPlayer = GetComponent<Rigidbody>();

        // If no camera is assigned, use the main camera
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player based on input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        movement = new Vector3(x, 0, z);

        // Calculate movement direction relative to the camera
        if (movement.magnitude > 0.1f)
        {
            Vector3 cameraForward = cameraTransform.forward;
            Vector3 cameraRight = cameraTransform.right;

            // Ignore y-axis
            cameraForward.y = 0f;
            cameraRight.y = 0f;

            cameraForward.Normalize();
            cameraRight.Normalize();

            // Final movement direction
            Vector3 moveDirection = cameraForward * movement.z + cameraRight * movement.x;

            MovePlayer(moveDirection);
        }
    }

    private void MovePlayer(Vector3 direction)
    {
        // Calculate movement
        Vector3 movement = direction * speed * Time.deltaTime;
        rbPlayer.MovePosition(transform.position + movement);

        // Orient the player towards the movement direction
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.gameObject;
        Debug.Log($"Collided with {collidedWith.name}");

        if (collidedWith.CompareTag("Eatable"))
        {
            // Increment the carrot counter via GameManager
            GameManager.Instance.IncrementCarrotsEaten();

            // Destroy the carrot
            Destroy(collidedWith);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter:" + other.gameObject.tag);
        if (other.CompareTag("FinishZone"))
        {
            Debug.Log("Level Complete");
            if (level < SceneManager.sceneCountInBuildSettings - 1)
            {
                SceneManager.LoadScene(level + 1);
            }
            else
            {
                Debug.Log("Game Complete");
                SceneManager.LoadScene(0);
            }
        }
    }
}

    /*
    private CharacterController _controller;

    [SerializeField]
    private float _playerSpeed = 5f;

    [SerializeField]
    private float _rotationSpeed = 10f;

    [SerializeField]
    private Camera _followCamera;

    private Vector3 _playerVelocity;
    private bool _groundedPlayer;

    [SerializeField]
    private float _jumpHeight = 1.0f;
    [SerializeField]
    private float _gravityValue = -9.81f;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        _groundedPlayer = _controller.isGrounded;
        if (_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementInput = Quaternion.Euler(0, _followCamera.transform.eulerAngles.y, 0) * new Vector3(horizontalInput, 0, verticalInput);
        Vector3 movementDirection = movementInput.normalized;

        _controller.Move(movementDirection * _playerSpeed * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, _rotationSpeed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && _groundedPlayer)
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
        }

        _playerVelocity.y += _gravityValue * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);
    }*/
