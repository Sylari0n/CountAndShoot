using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private float _ballStackDelay = 1f;
    [SerializeField] private float _delayBetweenBalls = 0.8f;
    [SerializeField] public float hitPower = 10f;
    [SerializeField] private float _ballJumpForce = 8f;

    [SerializeField] private float _ballRightForce = 1f;

    public static int ballCount = 0;

    // For One Period of Ball Throw and hit
    public static bool _stackState = false;
    public List<GameObject> ballStack = new List<GameObject>();
    



    void Update()
    {
        StackStateCheck();
        StackBall();
        CreateBall();
        Debug.Log(ballCount);

    }

    private void Timer()
    {
        _timer += Time.deltaTime;
    }

    private void StackStateCheck()
    {
        // There are ball in the stack
        if (ballCount > 0 && !PlayerControls.isPressing) { _stackState = true;}
        // There are no ball in the stack
        if (ballCount == 0 && ballStack.Count == 0) { _stackState = false; }
        Debug.Log(_stackState);
    }
    
    private void StackBall()
    {
        if (PlayerControls.isPressing && !_stackState)
        {
            Timer();
            if (ballCount >= 5) { return; }
            if (_timer >= _ballStackDelay)
            {
                int _instantiateCount = _stepCount >= 1 ? 2 : 1;
                ballCount += _instantiateCount;
                _stepCount++;
                _timer = 0f;
            }
        }
    }

    private void CreateBall()
    {
        if (_stackState)
        {
            _stepCount = 0;
            Timer();
            if (ballCount == 0) { return; }
            if (_timer >= _delayBetweenBalls)
            {
                GameObject _tempBall;

                _tempBall = Instantiate(_ballPrefab, GetComponent<Transform>().position, Quaternion.identity);
                ballStack.Add(_tempBall);

                _tempBall.GetComponent<Rigidbody>().velocity = Vector3.up * _ballJumpForce +
                    Vector3.right * FindObjectOfType<PlayerControls>()._playerVelocity * _ballRightForce;
                

                ballCount--;
                _timer = 0;   
            }
        }
    }



    // Private Fields

    private int _stepCount = 0;
    private Transform _spawnPointLocation;
    private float _timer = 0f;
}
