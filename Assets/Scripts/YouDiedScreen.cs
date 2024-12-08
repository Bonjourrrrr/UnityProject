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
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(0);
    }
}
