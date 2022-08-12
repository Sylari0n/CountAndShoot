using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirHitbox : MonoBehaviour
{
    
    [SerializeField] private float airShotPowerY = 9f;
    [SerializeField] private float airShotPowerX = 6f;
   
    public static bool isAir = false;
    public static bool stillAir = false;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ball")
         {
            stillAir = true;
         }
        if (other.gameObject.tag == "Ball" && !DirectHitbox.isDirect && PlayerControls.isPressed && !PlayerControls.isPressing)
        {
            isAir = true;
            DirectHitbox.isDirect = false;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.up * airShotPowerY + 
                Vector3.forward * airShotPowerX; 
            // FindObjectOfType<BallScript>().ballStack.Find( ball => ball.gameObject == other.gameObject).GetComponent<Rigidbody>().velocity =
            //     Vector3.up * 9f + Vector3.right * 10f;
            other.gameObject.GetComponent<SphereCollider>().isTrigger = false;
            FindObjectOfType<BallScript>().ballStack.Remove(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            stillAir = false;
        }
        if (other.gameObject.tag == "Ball")
        {
            isAir = false;
        }
    }
}
