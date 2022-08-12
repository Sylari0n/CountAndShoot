using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinScreen : MonoBehaviour
{
    [SerializeField] GameObject _playerObj;
    [SerializeField] TMP_Text winScreenText;
    
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
        if (_playerObj)
        {
            if (FindObjectOfType<PlayerControls>().isFnished == true)
            {
                winScreenText.text = "Level " + SceneManager.GetActiveScene().buildIndex + " Passed";
                gameObject.GetComponent<Canvas>().enabled = true;
            }
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
