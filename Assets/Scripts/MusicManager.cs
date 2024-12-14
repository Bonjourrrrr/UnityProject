using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;  

public class MusicManager : MonoBehaviour
{
    private static MusicManager thisInstance;

    void Start()
    {
        if (thisInstance == null) // if there is no instance of the MusicManager it is created
        {
            thisInstance = this;
            DontDestroyOnLoad(thisInstance);
        }
        else // if there is an instance of the MusicManager it is destroyed
        {
            Destroy(this.gameObject);
        }
    }
}