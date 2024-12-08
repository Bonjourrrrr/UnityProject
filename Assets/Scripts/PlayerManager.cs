using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public Rigidbody rbPlayer;
    private MeshRenderer meshRendererPlayer;
    private int level;

    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        meshRendererPlayer = GetComponent<MeshRenderer>();
        rbPlayer = GetComponent<Rigidbody>();

    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.gameObject;
        Debug.Log($"Bunny collided with {collidedWith.name}");

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
