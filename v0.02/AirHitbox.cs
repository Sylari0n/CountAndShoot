using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirHitbox : MonoBehaviour
{
    public static bool isAir = false;
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ball" && !DirectHitbox.isDirect && PlayerControls.isPressed)
        {
            isAir = true;
            DirectHitbox.isDirect = false;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.up * 9f + Vector3.right * (FindObjectOfType<BallScript>().hitPower - 2); 
            // FindObjectOfType<BallScript>().ballStack.Find( ball => ball.gameObject == other.gameObject).GetComponent<Rigidbody>().velocity =
            //     Vector3.up * 9f + Vector3.right * 10f;
            FindObjectOfType<BallScript>().ballStack.Remove(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            isAir = false;
        }
    }
}
