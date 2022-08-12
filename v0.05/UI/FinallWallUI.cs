using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinallWallUI : MonoBehaviour
{
    
    [SerializeField] TMP_Text finalWallText;
    [SerializeField] int FinalHitPoint;
    private int tempHitPoint;

    void Start()
    {
        tempHitPoint = FinalHitPoint;
    }

    void Update()
    {
        finalWallText.text = tempHitPoint.ToString();
        WallLifeChecker();
    }

    void WallLifeChecker()
    {
        if (tempHitPoint == 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            tempHitPoint--;
        }

        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
        }
    }
}
