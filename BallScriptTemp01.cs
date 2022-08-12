using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{


    // Static Fields
    [SerializeField] GameObject _ballPrefab;
    [SerializeField] float _ballStackDelay = 1f;
    [SerializeField] float _delayBetweenBalls = 1f;
    [SerializeField] public float _ballJumpForce = 11f;
    [SerializeField] public float _delayBeforeThrow = 0.5f;
    [SerializeField] float _jumpForceForOneBall = 8f;

   
    public static bool isThrowing = false;
    public static int stepCounter = 0;
    public static int ballCount = 0;
    public static float timer = 0f;    
    public static int maxBall = 0;
    public static bool isStepOne = true;
    [HideInInspector] public float _tempJumpForce;
   
   
    PlayerControl _playerControl;
    Rigidbody  _rbBall;
    Transform _spawnPointLocation;

    void Start()
    {
        _tempJumpForce = _ballJumpForce;
    }

    void Update()
    {
        _spawnPointLocation = GetComponent<Transform>();
        StackBall();
        CreateBall();
    }

    void Timer()
    {
        timer += Time.deltaTime;
    }
    
    // Temp Code
    void ContinueMoving()
    {
        PlayerControl._isPressing = false;
    }

    void StackBall()
    {
        if (PlayerControl._isPressing)
        {
            
            Timer();
            if(ballCount >= 5) {  return; }
            if (timer >= _ballStackDelay)
            {
                isThrowing = true;
                int instantiateBallCount = stepCounter >= 1 ? 2 : 1;
                ballCount += instantiateBallCount;
                stepCounter++;
                if (stepCounter > 1)
                {
                    isStepOne = false;
                    Debug.Log(isStepOne);
                }
                maxBall = ballCount;
                Debug.Log(stepCounter);
                timer = 0;
            }
        }
    }

    void CreateInstance()
    {       
            Debug.Log(_ballJumpForce);
            GameObject _ballClone;
            _ballClone = Instantiate(_ballPrefab, _spawnPointLocation.position, Quaternion.identity);
            _rbBall = _ballClone.GetComponent<Rigidbody>();
            // _rbBall.velocity = Vector3.up * _ballJumpForce;
            _rbBall.velocity = Vector3.up * _ballJumpForce + Vector3.right * 0.2f;
            
    }

    void CreateBall()
    {
        if (isThrowing && PlayerControl._isPressing == false && ballCount > 0)
        {
            Timer();
            if (ballCount == 0) { return; }
            if (timer >= _delayBetweenBalls)
            {
                Debug.Log(isStepOne);
                if (isStepOne)
                {
                    _ballJumpForce = _jumpForceForOneBall;
                }
                Invoke(nameof(CreateInstance), _delayBeforeThrow);
                ballCount -= 1;
                timer = 0;
            }
        }
    }

   
}
