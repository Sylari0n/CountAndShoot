using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCapsule : MonoBehaviour
{
    [SerializeField] GameObject _bonusBall;
    [SerializeField] float _ballDropTimer = 0.5f;
    [SerializeField] int _totalBonusBall = 10;


    private Animator _boxAnimator;

    void Start()
    {
        _boxAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        CreateBonusBall();
        DropBall();
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.tag == "Ball")
    //     {
    //         _isTouched = true;
    //     }
    // }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            _isTouched = true;

            Destroy(other.gameObject);
        }
    }



    void CreateBonusBall()
    {
        if (_isTouched)
        {
            if (_totalBonusBall <= 0) { return; }
            Timer();
            if (_timer >= _ballDropTimer)
            {
                _tmpBall = Instantiate(_bonusBall, GetComponent<Transform>().position, Quaternion.identity);
                _tmpBall.GetComponent<Rigidbody>().velocity = Vector3.back * 0.15f;
                _timer = 0;
                _totalBonusBall--;
            }
        }
        // gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    void Timer()
    {
        _timer += Time.deltaTime;
    }

    
    // Animation Zone
    void DropBall()
    {
        if (_isTouched)
        {
            _boxAnimator.SetTrigger("BoxHit");
        }
    }

    private GameObject _cpyBall;
    private GameObject _tmpBall;
    private float _timer = 0f;
    private bool _isTouched = false;
}
