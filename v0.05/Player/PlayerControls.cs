using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{

    [SerializeField] public float _playerVelocity = 10f;
    [SerializeField] private float _playerVelocityWithBall = 5f;
    [SerializeField] public float _playerStopDelay = 0.2f;
    [SerializeField] GameObject _gameOverScreen;
    

    public static bool isPressed = false;
    public static bool isPressing = false;

    public bool isFnished = false;

    private float _timer = 0f;


    void Update()
    {
        IsPressing();
        PlayerMoveController();
        MovePlayer();
    }

     void Timer()
    {
        _timer += Time.deltaTime;
    }


    private void MovePlayer()
    {
        if (isFnished) { return; }
        if (canMove == true)
        {
            transform.Translate(Vector3.forward * _playerVelocity * Time.deltaTime);
        }
        else if(canMove == false)
        {
            transform.Translate(Vector3.forward * _playerVelocityWithBall * Time.deltaTime);
        }
    }

    void PlayerMoveController()
    {
        if (BallScript.ballCount > 0 || FindObjectOfType<BallScript>().ballStack.Count > 0)
        {
            canMove = false;
        }
        else if (BallScript.ballCount == 0 || FindObjectOfType<BallScript>().ballStack.Count == 0)
        {
            canMove = true;
        }
    }

    // Player Control
    void IsPressing()
    {
        if (isPressed)
        {
            Timer();
            if (_timer >= _playerStopDelay)
            {
                isPressing = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && gameObject)
        {
            Destroy(gameObject);
        }
    }

    public void Pressed()
    {
        isPressed = true;
    }

    public void Released()
    {
        isPressed = false;
        isPressing = false;
        _timer = 0f;
    }



    private bool canMove = true;
}
