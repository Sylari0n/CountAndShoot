using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinScreen : MonoBehaviour
{
    [SerializeField] GameObject _playerObj;
    [SerializeField] TMP_Text winScreenText;
    [SerializeField] Canvas _controlUi;
    
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
                _controlUi.enabled = false;
                winScreenText.text = "Level " + SceneManager.GetActiveScene().buildIndex + " Passed";
                gameObject.GetComponent<Canvas>().enabled = true;
            }
        }
    }

    public void NextLevel()
    {
        Invoke(nameof(NextLevelStarter), 0.1f);
    }

    void NextLevelStarter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
