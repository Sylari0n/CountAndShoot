using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectHitbox : MonoBehaviour
{
    [SerializeField] private float ShootPowerx = 26f;
    [SerializeField] private float ShootPowerY = 4f;
    [SerializeField] private GameObject _directHitboxUI;

    
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ball") 
        {
            _directHitboxUI.GetComponent<SpriteRenderer>().color = new Color(0.3191751f, 0.9811321f, 0f, 0.427451f);
            if (PlayerControls.isPressed && !PlayerControls.isPressing)
            {
                _directHitboxUI.GetComponent<SpriteRenderer>().color = new Color(0.3191751f, 0.9811321f, 0f, 0.6666666f);
                
                other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.up * ShootPowerY + 
                        Vector3.forward * ShootPowerx; 
                
                other.gameObject.GetComponent<SphereCollider>().isTrigger = false;
                FindObjectOfType<BallScript>().ballStack.Remove(other.gameObject);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            _directHitboxUI.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.427451f);
        }
    }
}
