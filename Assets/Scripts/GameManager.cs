using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int level;
    private string levelName;
    public static GameManager Instance { get; private set; } // Singleton instance
    private int totalCarrotsEaten = 0;


    // Start is called before the first frame update
    void Start()
    {
        //levelName = SceneManager.GetActiveScene().name;
        level = SceneManager.GetActiveScene().buildIndex;
        //manager = this.gameObject;
        Debug.Log($"Level: {level}") ;

        // Singleton setup
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy duplicate GameManager
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Preserve GameManager across scenes
    }

    // Update is called once per frame
    void Update()
    {


        /*int numCarrots = manager.transform.childCount;
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
        }*/
    }

    public void IncrementCarrotsEaten()
    {
        totalCarrotsEaten++;
        Debug.Log($"Carrots Eaten: {totalCarrotsEaten}");
    }

    public int GetCarrotsEaten()
    {
        return totalCarrotsEaten;
    }


}
