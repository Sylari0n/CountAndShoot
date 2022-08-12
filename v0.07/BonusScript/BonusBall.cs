using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBall : MonoBehaviour
{
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<BallScript>().totalBallCount++;
            Destroy(gameObject);
        }
    }
}
