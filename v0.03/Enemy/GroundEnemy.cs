using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            _isDefeated = true;
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }

        
    }

    void OnTriggerEnter(Collider other)
    {
        if (!_isDefeated && other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
        }
    }

    private bool _isDefeated = false;
}
