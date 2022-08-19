using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomHitbox : MonoBehaviour
{
    [SerializeField] public float ShootPowerX = 26f;
    [SerializeField] public float ShootPowerY = 4f;
    [SerializeField] private GameObject _bottomHitboxUI;
    [SerializeField] private GameObject _playerObj;
    [SerializeField] private GameObject _ballObj;

    public bool isBottom = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball" && other.gameObject == _ballObj.GetComponent<BallScript>().ballStack[0])
        {
            isBottom = true;
            _bottomHitboxUI.GetComponent<SpriteRenderer>().color = new Color(0.3191751f, 0.9811321f, 0f, 0.427451f);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball" && other.gameObject == _ballObj.GetComponent<BallScript>().ballStack[0])
        {
            isBottom = false;
            _bottomHitboxUI.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.427451f);
        }
    }
}
