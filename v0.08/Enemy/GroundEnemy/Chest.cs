using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{ 
    [SerializeField] GameObject _monsterObj;
    public bool isChest = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            isChest = true;
            // FindObjectOfType<GroundEnemy>().tmpTotalHp -= FindObjectOfType<GroundEnemy>()._chestHitbox;   
            _monsterObj.GetComponent<GroundEnemy>().tmpTotalHp -= _monsterObj.GetComponent<GroundEnemy>()._chestHitbox;
            other.gameObject.tag = "null";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball" || other.gameObject.tag == "null")
        {
            isChest = false;
        }
    }

}
