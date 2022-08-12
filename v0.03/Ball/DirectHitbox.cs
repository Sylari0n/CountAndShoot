using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectHitbox : MonoBehaviour
{
    
    [SerializeField] private float directShotPowerY = 3f;
    [SerializeField] private float directShotPowerX = 20f;
    
    public static bool isDirect = false;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ball" && !AirHitbox.isAir && PlayerControls.isPressed && !PlayerControls.isPressing)
        {
            isDirect = true;
            AirHitbox.isAir = false;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.up * directShotPowerY + 
                Vector3.forward * directShotPowerX;
            // FindObjectOfType<BallScript>().ballStack.Find( ball => ball.gameObject == other.gameObject).GetComponent<Rigidbody>().velocity =
            //     Vector3.up * 3f + Vector3.right * 16f;
            other.gameObject.GetComponent<SphereCollider>().isTrigger = false;
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
