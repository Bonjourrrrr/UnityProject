using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed, groundDrag, playerHeight; // player movement variables
    public Transform orientation; // player orientation
    public LayerMask whatIsGround; // ground layer

    private float horizontalInput; // input variables
    private float verticalInput;
    private Vector3 moveDirection; // movement direction
    private Rigidbody rb; // player rigidbody
    private bool grounded; // is player grounded

    private Animator anim;
    public float x, y;




    private void Start()
    {
        // get components and freeze rotation
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        anim = GetComponent<Animator>();

    }
    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f, whatIsGround);

        // get input
        MyInput();

        // speed control
        SpeedControl();

        // handle drag
        if (grounded)
        {
            rb.drag = groundDrag; 
        }
        else
        {
            rb.drag = 0;
        }

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);
    }
    private void FixedUpdate() // physics update with camera orientation
    {
        MovePlayer();
    }
    private void MyInput() // get input from player
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * speed * 5.0f, ForceMode.Force);
    }
    private void SpeedControl()
    {
        // limit speed effectively
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVel.magnitude > speed) 
        {
            Vector3 limitVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z);
        }
    }


   
}
