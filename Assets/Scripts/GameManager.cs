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
        level = SceneManager.GetActiveScene().buildIndex;
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
