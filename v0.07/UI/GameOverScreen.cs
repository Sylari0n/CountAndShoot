using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    [SerializeField] GameObject _playerObj;
    [SerializeField] Canvas _tapToPlayCanvas;

    void Start()
    {
        // gameObject.SetActive(false);
        gameObject.GetComponent<Canvas>().enabled = false;
    }

    void Update()
    {
        DisplayGameOverScreen();
    }

    void DisplayGameOverScreen()
    {
        if (!_playerObj)
        {
            gameObject.GetComponent<Canvas>().enabled = true;
        }
    }

    public void RestartScene()
    {
        Invoke(nameof(ReLoadLevel), 0.1f);
    }

    void ReLoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
