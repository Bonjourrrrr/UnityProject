using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouDiedScreen : MonoBehaviour
{
    private AudioSource jumpscare; // load the jumpscare sound
    void Start()
    {
        // unlock the cursor and make it visible
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;

        // play the jumpscare sound
        jumpscare = GetComponent<AudioSource>();
        jumpscare.Play();

        // wait for 2 seconds before loading the scene
        StartCoroutine(WaitBeforeContinue());
    }
    private IEnumerator WaitBeforeContinue()
    {
        Debug.Log("Waiting for 2 seconds");
        yield return new WaitForSeconds(2f);

        Debug.Log("Loading scene");

        // load the good game scene
        if (GameManager.Instance != null)
        {
            GameManager.Instance.Load();
        }
    }
}
