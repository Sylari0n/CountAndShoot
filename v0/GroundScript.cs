using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    public static int _ballCounter = 0;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            FindObjectOfType<BallScript>().instanceBallList.Remove(other.gameObject);
            Destroy(other.gameObject);
            _ballCounter++;
            if (_ballCounter == BallScript.maxBall)
            {
                BallScript.isThrowing = false;
                _ballCounter = 0;
                BallScript.isStackDone = false;
                Debug.Log("Array Length: " + FindObjectOfType<BallScript>().instanceBallList.Count);
            }
        }
    }
}
