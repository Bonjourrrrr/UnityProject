using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouDiedScreen : MonoBehaviour
{
    private AudioSource jumpscare;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None; // unlock the cursor
        Cursor.visible = true; // make the cursor visible
        jumpscare = GetComponent<AudioSource>();
        jumpscare.Play();
        StartCoroutine(WaitBeforeContinue());
    }
    private IEnumerator WaitBeforeContinue()
    {
        Debug.Log("Waiting for 2 seconds");
        yield return new WaitForSeconds(2f);
        Debug.Log("Loading scene");
        if (GameManager.Instance != null)
        {
            GameManager.Instance.Load();
        }
    }
}
