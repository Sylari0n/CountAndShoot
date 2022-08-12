using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirShot : MonoBehaviour
{
    public static bool isAirShot = false;
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ball") 
        { 
            isAirShot = true;
            DirectShot.isDirectShot = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            isAirShot = false;
        }
    }
}
