using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirHitbox : MonoBehaviour
{
    [SerializeField] private float ShootPowerx = 26f;
    [SerializeField] private float ShootPowerY = 4f;
    [SerializeField] private GameObject _airHitboxUI;


    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            _airHitboxUI.GetComponent<SpriteRenderer>().color = new Color(0.3191751f, 0.9811321f, 0f, 0.427451f);
            if (PlayerControls.isPressed && !PlayerControls.isPressing)
            {
                _airHitboxUI.GetComponent<SpriteRenderer>().color = new Color(0.3191751f, 0.9811321f, 0f, 0.6666666f);
                Debug.Log("Air Working !!");
                
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
            _airHitboxUI.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.427451f);
        }
    }
}
