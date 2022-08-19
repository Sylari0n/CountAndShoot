using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _ballCountText;
    [SerializeField] private TMP_Text _totalBallCountText;
    [SerializeField] private GameObject _ballSpawnerObj;


    void Update()
    {
        _ballCountText.text = _ballSpawnerObj.GetComponent<BallScript>().ballCount.ToString();
        _totalBallCountText.text = FindObjectOfType<BallScript>().totalBallCount.ToString();
        currentBall = _ballSpawnerObj.GetComponent<BallScript>().totalBallCount;
        TotalBallTextHandler();
    }

    void TotalBallTextHandler()
    {
        if ( currentBall != _ballSpawnerObj.GetComponent<BallScript>().totalBallCount)
        {
            // _totalBallCountText.transform.position += 
            // new Vector3(0, 0, -(_ballSpawnerObj.GetComponent<BallScript>().totalBallCount) - 100);
        
            
        }
    }

    private float currentBall;
}
