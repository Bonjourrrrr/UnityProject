using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouDiedScreen : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(WaitBeforeContinue());
    }
    private IEnumerator WaitBeforeContinue()
    {
        Debug.Log("Waiting for 2 seconds");
        yield return new WaitForSeconds(2f);
        Debug.Log("Loading scene 0");
        SceneManager.LoadScene(0);
    }
}
