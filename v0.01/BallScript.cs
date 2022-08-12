using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{


    // Static Fields
    [SerializeField] GameObject _ballPrefab;
    [SerializeField] float _stackDelayBetweenBalls = 1f;
    [SerializeField] float _delayBetweenBalls = 1f;
    [SerializeField] public float _ballJumpForce = 11f;
    [SerializeField] public float _delayBeforeThrow = 0.5f;
    [SerializeField] float _jumpForceForOneBall = 8f;
    [SerializeField] public float rightForce = 10f;
    [SerializeField] float _airHitForce = 10f;
    

   
    public List<GameObject> instanceBallList = new List<GameObject>();
    public static bool isStackDone = false;
    public static bool isThrowing = false;
    public static bool isStepOne = true;
    public static int stepCounter = 0;
    public static int ballCount = 0;
    public static int maxBall = 0;
    public static float timer = 0f;    
    [HideInInspector] public float tempJumpForce;
    [HideInInspector] public float tempRightForce;
    
    
    int _hitCounter;
    public static bool _isThrew = false;
    bool isForce = true;
    bool _isDoneAir = false;
    bool _isDoneDirect = false;
    PlayerControl _playerControl;
    Rigidbody  _rbBall;
    Transform _spawnPointLocation;
    GameObject _ballClone;

    void Start()
    {
        tempJumpForce = _ballJumpForce;
        tempRightForce = rightForce;
        
    }

    void Update()
    {
        _spawnPointLocation = GetComponent<Transform>();
        StackBall();
        CreateBall();
        HitTheBall();
    }

    void Timer()
    {
        timer += Time.deltaTime;
    }

    void StackBall()
    {    
        if (!isStackDone)
        {
            Timer();
            if(ballCount >= 5) {  return; }
            if (PlayerControl._isPressing)
            {
                if (timer >= _stackDelayBetweenBalls)
                {
                    isThrowing = true;
                    int instantiateBallCount = stepCounter >= 1 ? 2 : 1;
                    ballCount += instantiateBallCount;
                    stepCounter++;
                    if (stepCounter > 1)
                    {
                        isStepOne = false;
                    }
                    maxBall = ballCount;
                    timer = 0;
                }
            }
        }
    }

    void CreateInstance()
    {       
            _ballClone = Instantiate(_ballPrefab, _spawnPointLocation.position, Quaternion.identity);
            instanceBallList.Add(_ballClone);
            Debug.Log("Current ball in the List: " + instanceBallList.Count);
            _rbBall = _ballClone.GetComponent<Rigidbody>();
            _rbBall.velocity = Vector3.up * _ballJumpForce + Vector3.right * rightForce;
            
    }

    void CreateBall()
    {
        if (isThrowing && ballCount > 0 && !PlayerControl._isPressing)
        {
            isStackDone = true;
            Timer();
            if (ballCount == 0) { return; }
            if (timer >= _delayBetweenBalls)
            {
                if (isStepOne)
                {
                    _ballJumpForce = _jumpForceForOneBall;
                    rightForce = 1.2f;
                }
                Invoke(nameof(CreateInstance), _delayBeforeThrow);
                
                ballCount -= 1;
                timer = 0;
            }
        }
    }

    void HitTheBall()
    {
        if (BallScript.isThrowing)
        {
            if (PlayerControl.isPressed)
            {
                if ( AirShot.isAirShot)
                {
                    if (isForce)
                    {
                        instanceBallList[0].GetComponent<Rigidbody>().velocity = Vector3.zero;
                        isForce = false;
                    }
                    if (!_isDoneAir)
                    {
                        instanceBallList[0].GetComponent<Rigidbody>().AddForce(Vector3.right * FindObjectOfType<PlayerControl>().hitPower + Vector3.up * _airHitForce);
                        _isDoneAir = true;
                        _isThrew = true;
                    }
                    if (PlayerControl.isPressed && _isDoneAir)
                    {
                        _isDoneAir = false;
                        isForce = true;
                    }
                }

                // Direct Shot Function
                if (DirectShot.isDirectShot)
                {
                    if (isForce)
                    {
                        instanceBallList[0].GetComponent<Rigidbody>().velocity = Vector3.zero;
                        isForce = false;
                    }
                    if (!_isDoneDirect)
                    {
                        instanceBallList[0].GetComponent<Rigidbody>().AddForce(Vector3.right * FindObjectOfType<PlayerControl>().hitPower * 2);
                        _isDoneDirect = true;
                        _isThrew = true;
                    }
                    if (PlayerControl.isPressed && _isDoneDirect)
                    {
                        _isDoneDirect = false;
                        isForce = true;
                    }
                }
            }
            
        }
    }   
}
