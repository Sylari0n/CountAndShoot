using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{ 
    [SerializeField] GameObject _monsterObj;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            // FindObjectOfType<GroundEnemy>().tmpTotalHp -= FindObjectOfType<GroundEnemy>()._chestHitbox;   
            _monsterObj.GetComponent<GroundEnemy>().tmpTotalHp -= _monsterObj.GetComponent<GroundEnemy>()._chestHitbox;
        }
    }

}
