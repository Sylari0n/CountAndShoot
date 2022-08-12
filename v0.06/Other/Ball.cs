using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    void Update()
    {
        if (gameObject.GetComponent<Rigidbody>().velocity.y <= 0)
        {
            isStopUp = true;
        }
        else
        {
            isStopUp = false;
        }
    }

    void FixedUpdate()
    {
        CheckVelocitY();
    }
    
    void CheckVelocitY()
    {
        if (isStopUp)
        {
            Debug.Log("Working anti gravity");
            // For decrease the gravity and align ball for the hitboxes
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * FindObjectOfType<BallScript>().antiGravity);
        }
    }

    private bool isStopUp = false;
}
