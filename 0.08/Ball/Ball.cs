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
            // For decrease the gravity and align ball for the hitboxes
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * FindObjectOfType<BallScript>().antiGravity);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Ground")
        {
            Invoke(nameof(MakeBallGhost), 0.05f);
        }
    }

    void MakeBallGhost()
    {
        gameObject.GetComponent<SphereCollider>().isTrigger = true;
    }

    private bool isStopUp = false;
}
