using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserInterface : MonoBehaviour
{
    [SerializeField] TMP_Text _scoreCounterText;



    void Update()
    {
        _scoreCounterText.text = BallScript.ballCount.ToString();

    }
    
    
    
}
