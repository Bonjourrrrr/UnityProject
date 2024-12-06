using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int level;
    private string levelName;
    private GameObject manager;


    // Start is called before the first frame update
    void Start()
    {
        levelName = SceneManager.GetActiveScene().name;
        level = SceneManager.GetActiveScene().buildIndex;
        manager = this.gameObject;
        Debug.Log($"Level: {level}") ;
    }

    // Update is called once per frame
    void Update()
    {
        int numCarrots = manager.transform.childCount;
        if (numCarrots == 0)
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
