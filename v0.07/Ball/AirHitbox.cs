using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirHitbox : MonoBehaviour
{
    [SerializeField] public float ShootPowerX = 26f;
    [SerializeField] public float ShootPowerY = 4f;
    [SerializeField] private GameObject _airHitboxUI;
    [SerializeField] private GameObject _playerObj;
    [SerializeField] private GameObject _ballObj;

    public bool isAir = false;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball" && other.gameObject == _ballObj.GetComponent<BallScript>().ballStack[0])
        {
            _airHitboxUI.GetComponent<SpriteRenderer>().color = new Color(0.3191751f, 0.9811321f, 0f, 0.427451f);
            isAir = true;

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball" && other.gameObject == _ballObj.GetComponent<BallScript>().ballStack[0])
        {
            _airHitboxUI.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.427451f);
            isAir = false;
        }
    }
}
