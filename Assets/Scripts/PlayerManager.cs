using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private MeshRenderer meshRendererPlayer;
    private Rigidbody rbPlayer;
    private float x, y, z;
    public float speed = 1.5f; // speed of the player
    private Vector3 movement;
    private GameObject gameManager;
    public Transform cameraTransform;


    // Start is called before the first frame update
    void Start()
    {
        meshRendererPlayer = GetComponent<MeshRenderer>();
        rbPlayer = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager");

        // if no camera is assigned, use the main camera
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // move the player
        x = Input.GetAxis("Horizontal") * speed;
        y = Input.GetAxis("Jump") * speed;
        z = Input.GetAxis("Vertical") * speed;
        movement = new Vector3(x, y, z);
        rbPlayer.velocity = movement;

        // move the camera
        if (movement.magnitude > 0.1f)
        {
            Vector3 cameraForward = cameraTransform.forward;
            Vector3 cameraRight = cameraTransform.right;

            // ignore y axis
            cameraForward.y = 0f;
            cameraRight.y = 0f;

            cameraForward.Normalize();
            cameraRight.Normalize();

            // final movement direction
            Vector3 moveDirection = cameraForward * movement.z + cameraRight * movement.x;

            MovePlayer(moveDirection);
        }
    }
        
    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.gameObject;
        GameObject collider = this.gameObject;
        Debug.Log($"Collided with {collidedWith.name}");
        string tagCollidedWith = collidedWith.tag;
        string tagCollider = collider.tag;
        if (tagCollidedWith == "Eatable")
        {
            Destroy(collidedWith);
        }
    }

    private void MovePlayer(Vector3 direction)
    {
        Vector3 movement = direction * speed * Time.deltaTime;
        rbPlayer.MovePosition(transform.position + movement);

        //orientation of the player
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.deltaTime);
        }


    }
}
