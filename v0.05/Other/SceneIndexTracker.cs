using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneIndexTracker : MonoBehaviour
{
    
    public static int levelIndex;

    void Start()
    {
        levelIndex = SceneManager.GetActiveScene().buildIndex;
    }

}
