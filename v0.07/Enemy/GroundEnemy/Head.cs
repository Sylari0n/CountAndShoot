using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField] GameObject _monsterObj;
    public bool  isHead = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            isHead = true;
            // FindObjectOfType<GroundEnemy>().tmpTotalHp -= FindObjectOfType<GroundEnemy>()._headHitBox;
            _monsterObj.GetComponent<GroundEnemy>().tmpTotalHp -= _monsterObj.GetComponent<GroundEnemy>()._headHitBox;
            other.gameObject.tag = "null";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball" || other.gameObject.tag == "null")
        {
            isHead = false;
        }
    }
}
