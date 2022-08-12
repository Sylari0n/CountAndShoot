using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControllerScript : MonoBehaviour
{
    
    [SerializeField] GameObject _ballScript;
    GameObject _tempBall;

    void OnTriggerExit(Collider other)
    {
        // _ballScript.GetComponent<BallScript>().ballStack.RemoveAt(0);
        if (other.gameObject.tag == "Ball")
        {
            _tempBall = other.gameObject;
            Invoke(nameof(RemoveBall), 0.06f);
        }
    }

    void RemoveBall()
    {
        FindObjectOfType<BallScript>().ballStack.Remove(_tempBall);
    }

}
