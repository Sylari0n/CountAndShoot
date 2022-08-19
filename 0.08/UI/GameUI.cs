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
    }
}
