using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBorder : MonoBehaviour
{
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Destroy(other.gameObject);
        }
    }

    void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.tag == "Ball")
        {
            Destroy(Other.gameObject);
        }
    }

}
