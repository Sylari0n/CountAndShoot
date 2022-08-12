using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [SerializeField] GameObject _playerObj;
    
    void Start()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
    }

    void Update()
    {
        DisplayWinScreen();
    }

    void DisplayWinScreen()
    {
        if (FindObjectOfType<PlayerControls>().isFnished == true)
        {
            gameObject.GetComponent<Canvas>().enabled = true;
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
