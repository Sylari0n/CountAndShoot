using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
   // Serialize Field Values
    [SerializeField] float _playerSpeed;
    [SerializeField] GameObject _ballPrefab;
    [SerializeField] float _ballSpawnerDelay = 0.5f;

    bool _isTouched = false;
    int _ballCounter = 0;
    float _ballTimer = 0f;
    int _stepCounter = 0;
    int _ballCounterSpam = 0;
    

    Transform _playerLocation;

    

    void Update()
    {
        _playerLocation = GetComponent<Transform>();
        MovePlayer();      
        Timer();

        
    }

    // Player Movement
    public void MovePlayer()
    {
        if (!_isTouched)
        {
            transform.Translate(Vector3.right * _playerSpeed * Time.deltaTime);
        }
    }

    void CreateBallBasedOnTime()
    {
        if (_ballCounter >= 5) { return; }
        if (_ballTimer >= 1)
        {
            int instantiateBallCount = _stepCounter >= 1 ? 2 : 1;
            _ballCounterSpam += instantiateBallCount;
            Debug.Log("instantiate ball count: "+instantiateBallCount);

            _stepCounter++;

            _ballTimer = 0;
        }
    }

    void CreateInstance()
    {    
            Instantiate(_ballPrefab, _playerLocation.position, Quaternion.identity);
    }

    void SpawnBall()
    {
        if (_ballCounter > 0)
        {
            InvokeRepeating(nameof(CreateInstance), _ballSpawnerDelay, _ballCounter);
            Debug.Log(_ballCounter);
            Debug.Log(_ballTimer);
        }
    }

    void Timer()
    {
        if (_isTouched)
        {
            _ballTimer += Time.deltaTime;
            Debug.Log(_ballTimer);
            CreateBallBasedOnTime();
        }
    }

    void CountBall()
    {
        if (_ballTimer == 5) { return; }
        if (_isTouched)
        {
            Timer();
        }
    }



    // Player Action Controls
    public void Pressed()
    {
        _isTouched = true;
    }

    public void Released()
    {
        
        _stepCounter = 0;
        _isTouched = false;
        _ballCounter = 0;
        _ballTimer = 0;
    }

}
