using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball" || other.gameObject.tag == "null")
        {
            Destroy(other.gameObject);
            FindObjectOfType<BallScript>().ballStack.Remove(other.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball" || other.gameObject.tag == "null")
        {
            Destroy(other.gameObject);
            FindObjectOfType<BallScript>().ballStack.Remove(other.gameObject);
        }
    }
}
