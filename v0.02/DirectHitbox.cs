using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectHitbox : MonoBehaviour
{
    public static bool isDirect = false;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ball" && !AirHitbox.isAir && PlayerControls.isPressed)
        {
            isDirect = true;
            AirHitbox.isAir = false;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.up * 3f + Vector3.right * (FindObjectOfType<BallScript>().hitPower + 12);
            // FindObjectOfType<BallScript>().ballStack.Find( ball => ball.gameObject == other.gameObject).GetComponent<Rigidbody>().velocity =
            //     Vector3.up * 3f + Vector3.right * 16f;
            FindObjectOfType<BallScript>().ballStack.Remove(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            isDirect = false;
        }
    }
}
