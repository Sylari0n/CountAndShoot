using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float _playerSpeed;

    public static bool _isPressed = false;

 

    void Update()
    {
        MovePlayer();      
    }

    
    // Player Movement
    public void MovePlayer()
    {
        if (!_isPressed && !BallScript.isThrowing)
        {
            transform.Translate(Vector3.right * _playerSpeed * Time.deltaTime);
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
        _isPressed = false;
        BallScript.timer = 0;  
    }

}
