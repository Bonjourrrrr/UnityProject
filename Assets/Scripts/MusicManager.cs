using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;  

public class MusicManager : MonoBehaviour
{
    private static MusicManager thisInstance;
    void Start()
    {
        if (thisInstance == null)
        {
            thisInstance = this;
            DontDestroyOnLoad(thisInstance);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}