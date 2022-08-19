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
    [SerializeField] private float _ballForwardForce = 1f;
    [SerializeField] protected int _totalBallCount = 30;
    [SerializeField] public float antiGravity = 2.5f;

    public int ballCount = 0;
    [HideInInspector] public int totalBallCount;

    // For One Period of Ball Throw and hit
    public bool _stackState = false;
    public bool _isBallZero = false; 
    public List<GameObject> ballStack = new List<GameObject>();
    

    void Start()
    {
        totalBallCount = _totalBallCount;
    }


    void Update()
    {
        StackStateCheck();
        TotalBallCountHandler();
        StackBall();
        CreateBall();
    }

    private void Timer()
    {
        _timer += Time.deltaTime;
    }

    void TotalBallCountHandler()
    {
        if (totalBallCount <= 0)
        {
            _isBallZero = true;
        }

        else
        {
            _isBallZero = false;
        }
    }

    private void StackStateCheck()
    {
        // There are ball in the stack
        if (ballCount > 0 && !PlayerControls.isPressing) { _stackState = true;}
        // There are no ball in the stack
        if (ballCount == 0 && ballStack.Count == 0) { Invoke(nameof(StackStateDelay), 0.05f); }
    }
    void StackStateDelay()
    {
        _stackState = false;
    }
    
    private void StackBall()    
    {
        if (PlayerControls.isPressing && !_stackState)
        {
            Timer();
            if (ballCount == 5) { return; }
            if (_isBallZero) { return; }
            if (_timer >= _ballStackDelay)
            {
                if (totalBallCount == 4 && _stepCount == 2) {ballCount = 4; return; }
                else if (totalBallCount == 3 && _stepCount == 2) { return; }
                else if (totalBallCount == 2 && _stepCount == 1) {ballCount = 2; return; }
                else if (totalBallCount == 1 && _stepCount == 1) { return; }
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
                // For Ball extraction
                GameObject _tempBall;

                _tempBall = Instantiate(_ballPrefab, GetComponent<Transform>().position, Quaternion.identity);
                ballStack.Add(_tempBall);

                _tempBall.GetComponent<Rigidbody>().velocity = Vector3.up * _ballJumpForce +
                    Vector3.forward * FindObjectOfType<PlayerControls>()._playerVelocity * _ballForwardForce;              
                totalBallCount--;
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
