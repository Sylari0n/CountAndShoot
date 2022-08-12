using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _ballCountText;
    [SerializeField] private TMP_Text _totalBallCountText;

    void Update()
    {
        _ballCountText.text = BallScript.ballCount.ToString();
        _totalBallCountText.text = FindObjectOfType<BallScript>().totalBallCount.ToString();
    }
}
