using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    public Transform orientation; // orientation of the player
    public Transform player; // player object
    public Transform playerObj; // player object for combat camera style
    public Rigidbody rb; // rigidbody of the player
    public float rotationSpeed = 1.0f; // rotation speed of the camera
    public Transform combatLookAt; // for combat camera style


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // lock the cursor
        Cursor.visible = false; // make the cursor invisible
    }

    private void Update()
    {

        if (player != null && orientation != null)
        {
            // rotate orientation
            Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
            orientation.forward = viewDir.normalized;
        }

        if (combatLookAt != null && playerObj != null && orientation != null)
        {
            // rotate player object
            Vector3 inputDir = combatLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
            orientation.forward = inputDir.normalized;
            playerObj.forward = inputDir.normalized;
        }
    }
}
