using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Destroy(other.gameObject);
            FindObjectOfType<BallScript>().ballStack.Remove(other.gameObject);
        }
    }
}
