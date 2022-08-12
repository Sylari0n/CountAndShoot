using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Debug.Log("head");
            FindObjectOfType<GroundEnemy>().tmpTotalHp -= FindObjectOfType<GroundEnemy>()._headHitBox;
        }
    }
}
