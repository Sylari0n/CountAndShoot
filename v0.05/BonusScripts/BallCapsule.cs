using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCapsule : MonoBehaviour
{
    [SerializeField] GameObject _bonusBall;
    [SerializeField] float _ballDropTimer = 0.5f;
    [SerializeField] int _totalBonusBall = 10;

    void Update()
    {
        CreateBonusBall();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            _isTouched = true;
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
    }

    void Timer()
    {
        _timer += Time.deltaTime;
    }

    private GameObject _tmpBall;
    private float _timer;
    private bool _isTouched = false;
}
