using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
        }
    }
}
