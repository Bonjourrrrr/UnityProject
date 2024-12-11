using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start_Game()
    {
        Scene scene = SceneManager.GetActiveScene();

        int level = scene.buildIndex;

        Debug.Log($"currently in level: {level}");


        SceneManager.LoadScene(level + 1);
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
    }
}
