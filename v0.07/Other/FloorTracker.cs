using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorTracker : MonoBehaviour
{
    const string curSave = "Floor";

    void Start()
    {
        if (PlayerPrefs.GetInt(curSave) <= 0)
        {
            PlayerPrefs.SetInt(curSave, 1);
        }

        _FloorTracker();

    }

    void Update()
    {

    }

    void _FloorTracker()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt(curSave));
    }

    public static int ReturnFloor()
    {
        return PlayerPrefs.GetInt(curSave);
    }

    void EmbedLevel()
    {
        Debug.Log(PlayerPrefs.GetInt(curSave));
        PlayerPrefs.SetInt(curSave, SceneIndexTracker.levelIndex);
    }



}
