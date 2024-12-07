using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;
    public float rotationSpeed = 1.0f;
    public Transform combatLookAt; // for combat camera style


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; // make the cursor invisible
    }

    private void Update()
    {
        // rotate orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        // rotate player object
        Vector3 inputDir = combatLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
        orientation.forward = inputDir.normalized;
        playerObj.forward = inputDir.normalized;
    }
}
