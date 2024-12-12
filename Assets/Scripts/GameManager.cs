using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int level;
    public static GameManager Instance { get; private set; } // Singleton instance
    private int totalCarrotsEaten = 0;
    private bool loadLevel3 = false;
    private int previousCarrotsEaten = 0;

    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        Debug.Log($"Level: {level}");

        // Singleton setup
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy duplicate GameManager
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Preserve GameManager across scenes
    }

    void Update()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        // Save progress of level 2
        if (level == 3)
        {
            Debug.Log($"Save number of carrots of level 2");
            previousCarrotsEaten = totalCarrotsEaten;
        }

        // Save progress of levels 4 and 5
        if (level == 5 || level == 6)
        {
            Debug.Log("Will load level 3");
            loadLevel3 = true;
        }
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

    public void Load()
    {
        if (loadLevel3)
        {
            Debug.Log("We are after lvl 3");
            totalCarrotsEaten = previousCarrotsEaten;
            SceneManager.LoadScene(4);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
