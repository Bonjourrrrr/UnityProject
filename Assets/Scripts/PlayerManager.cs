using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private MeshRenderer meshRendererPlayer;
    private Rigidbody rbPlayer;
    private float x, y, z;
    public float speed = 8.0f;
    private Vector3 movement;
    private GameObject gameManager;


    // Start is called before the first frame update
    void Start()
    {
        meshRendererPlayer = GetComponent<MeshRenderer>();
        rbPlayer = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal")*speed;
        y = Input.GetAxis("Jump") * speed;
        z = Input.GetAxis("Vertical")*speed;
        movement = new Vector3(x, y, z);
        rbPlayer.velocity = movement;
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
}
