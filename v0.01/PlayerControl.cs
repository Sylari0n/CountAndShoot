using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{   
    [SerializeField] float _playerSpeed;
    [SerializeField] float _playerStopTimer;

    public float hitPower = 10f;

    public static bool isPressed = false;
    public static bool _isPressing = false;
    
    float _timer = 0f;
    public static Transform playerLocation;


    void Update()
    {
        playerLocation = GetComponent<Transform>();
        MovePlayer();   
        PlayerPressChecker();   
    }

    void Timer()
    {
        _timer += Time.deltaTime;
    }
    
    // Player Movement
    public void MovePlayer()
    {
        if (!_isPressing && !BallScript.isThrowing)
        {
            transform.Translate(Vector3.right * _playerSpeed * Time.deltaTime);
            BallScript.isStepOne = true;
            FindObjectOfType<BallScript>()._ballJumpForce = FindObjectOfType<BallScript>().tempJumpForce;
            FindObjectOfType<BallScript>().rightForce = FindObjectOfType<BallScript>().tempRightForce;
        }
    }


    void PlayerPressChecker()
    {
        if (isPressed)
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
        isPressed = true;
    }

    public void Released()
    {
        if (BallScript._isThrew && FindObjectOfType<BallScript>().instanceBallList.Count > 0)
        {
            try{FindObjectOfType<BallScript>().instanceBallList.RemoveAt(0);}
            catch{}
        }
        BallScript.stepCounter = 0;
        BallScript.timer = 0;  
        isPressed = false;
        _isPressing = false;
        _timer = 0;
        
    }    
}
