using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float _playerSpeed;
    [SerializeField] float _playerStopTimer = 1f;


    public static bool _isPressed = false;
    public static bool _isPressing = false;
    
    float _timer = 0f;


    void Update()
    {
        MovePlayer();   
        PlayerPressChecker();   
    }

    
    // Player Movement
    public void MovePlayer()
    {
        if (!_isPressing && !BallScript.isThrowing)
        {
            transform.Translate(Vector3.right * _playerSpeed * Time.deltaTime);
            BallScript.isStepOne = true;
            FindObjectOfType<BallScript>()._ballJumpForce = FindObjectOfType<BallScript>()._tempJumpForce;
        }
    }

    void Timer()
    {
        _timer += Time.deltaTime;
    }

    void PlayerPressChecker()
    {
        if (_isPressed)
        {
            Timer();
            if (_timer >= _playerStopTimer)
            {
                _isPressing = true;
            }
        }
    }


    // Player Action Controls
    public void Pressed()
    {
        _isPressed = true;
    }

    public void Released()
    {
        BallScript.stepCounter = 0;
        BallScript.timer = 0;  
        _isPressed = false;
        _isPressing = false;
        _timer = 0;
        
    }

}
