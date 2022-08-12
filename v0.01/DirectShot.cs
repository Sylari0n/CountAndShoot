using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectShot : MonoBehaviour
{
    public static bool isDirectShot = false;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ball") 
        { 
            isDirectShot = true; 
            AirShot.isAirShot = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            isDirectShot = false;
        }
    }
}
