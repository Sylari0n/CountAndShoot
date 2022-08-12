using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{ 
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Debug.Log("chest");
            FindObjectOfType<GroundEnemy>().tmpTotalHp -= FindObjectOfType<GroundEnemy>()._chestHitbox;   
        }
    }

}
