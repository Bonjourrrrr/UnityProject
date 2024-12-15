using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public Rigidbody rbPlayer; // Rigidbody component for the player
    private MeshRenderer meshRendererPlayer; // MeshRenderer component for the player
    private int level; // The current level index
    private AudioSource eaten; // AudioSource component for the sound of the carrot being eaten

    void Start()
    {
        // Get the current level index
        level = SceneManager.GetActiveScene().buildIndex;

        // Get the MeshRenderer, the Rigidbody components and the AudioSource component
        meshRendererPlayer = GetComponent<MeshRenderer>();
        rbPlayer = GetComponent<Rigidbody>();
        eaten = GetComponent<AudioSource>();

    }
    private void OnCollisionEnter(Collision collision) // This is a method that is called when the player collides with something
    {
        GameObject collidedWith = collision.gameObject;

        Debug.Log($"Bunny collided with {collidedWith.name}");

        // If the player collides with a carrot
        if (collidedWith.CompareTag("Eatable"))
        {
            // Increment the carrot counter via GameManager and play the sound
            eaten.Play();
            GameManager.Instance.IncrementCarrotsEaten();

            // Destroy the carrot
            Destroy(collidedWith);
        }
    }

   
    private void OnTriggerEnter(Collider other) // This is a method that is called when the player enters a trigger (the finish zone)
    {
        StartCoroutine(HandleTriggerEnter(other));
    }

    private IEnumerator HandleTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter:" + other.gameObject.tag);

        if (other.CompareTag("FinishZone")) // If the player enters the finish zone
        {
            Debug.Log("Level Complete");

            if (level == 6) // If the player is in level 6, check the number of carrots eaten and load the appropriate ending
            {
                if (GameManager.Instance.GetCarrotsEaten() > 7)
                {
                    SceneManager.LoadScene(8); // If the player has eaten more than 8 carrots, load the good ending
                }
                else
                {
                    SceneManager.LoadScene(7); // If the player has eaten 8 or fewer carrots, load the bad ending
                }
            }
            else if (level < SceneManager.sceneCountInBuildSettings - 1) // Load the next level if it exists
            {
                SceneManager.LoadScene(level + 1);
            }
            else
            {
                Debug.Log("Game Complete");
                SceneManager.LoadScene(0);
            }
        }
        yield return null;
    }

}
