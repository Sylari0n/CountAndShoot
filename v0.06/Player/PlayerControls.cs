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
    [SerializeField] GameObject _ballScript;
    [SerializeField] GameObject _airHitbox;
    [SerializeField] GameObject _directHitbox;
    [SerializeField] GameObject _bottomHitbox;
    

    public static bool isPressed = false;
    public static bool isPressing = false;
    public bool isFnished = false;
    public bool canMove = true;
    public bool isTapped = false;


    void Update()
    {
        IsPressing();
        PlayerMoveController();
        MovePlayer();
        ShootTheBall();
    }

     void Timer()
    {
        _timer += Time.deltaTime;
    }


    private void MovePlayer()
    {
        if (!isTapped || isFnished) { return; }
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

    // Ball Shoot Action
    void ShootTheBall()
    {
        if (_airHitbox.GetComponent<AirHitbox>().isAir)
        {
            if (isPressed && !isPressing)
            {
                _ballScript.GetComponent<BallScript>().ballStack[0].GetComponent<Rigidbody>().velocity =
                Vector3.up * _airHitbox.GetComponent<AirHitbox>().ShootPowerY +
                Vector3.forward * _airHitbox.GetComponent<AirHitbox>().ShootPowerX;

                _ballScript.GetComponent<BallScript>().ballStack[0].GetComponent<SphereCollider>().isTrigger = false;
                // _ballScript.GetComponent<BallScript>().ballStack.RemoveAt(0);
            }
        }
        else if (_directHitbox.GetComponent<DirectHitbox>().isDirect)
        {
            if (isPressed && !isPressing)
            {
                _ballScript.GetComponent<BallScript>().ballStack[0].GetComponent<Rigidbody>().velocity =
                Vector3.up * _directHitbox.GetComponent<DirectHitbox>().ShootPowerY +
                Vector3.forward * _directHitbox.GetComponent<DirectHitbox>().ShootPowerX;

                _ballScript.GetComponent<BallScript>().ballStack[0].GetComponent<SphereCollider>().isTrigger = false;
                // _ballScript.GetComponent<BallScript>().ballStack.RemoveAt(0);
            }
        }
        else if (_bottomHitbox.GetComponent<BottomHitbox>().isBottom)
        {
            if (isPressed && !isPressing)
            {
                Debug.Log("Working");
                _ballScript.GetComponent<BallScript>().ballStack[0].GetComponent<Rigidbody>().velocity =
                Vector3.up * _bottomHitbox.GetComponent<BottomHitbox>().ShootPowerY +
                Vector3.forward * _bottomHitbox.GetComponent<BottomHitbox>().ShootPowerX;

                _ballScript.GetComponent<BallScript>().ballStack[0].GetComponent<SphereCollider>().isTrigger = false;
                // _ballScript.GetComponent<BallScript>().ballStack.RemoveAt(0);
            }
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


    private float _timer = 0f;
    
}
