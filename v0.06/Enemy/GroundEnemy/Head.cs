using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField] GameObject _monsterObj;

    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            // FindObjectOfType<GroundEnemy>().tmpTotalHp -= FindObjectOfType<GroundEnemy>()._headHitBox;
            _monsterObj.GetComponent<GroundEnemy>().tmpTotalHp -= _monsterObj.GetComponent<GroundEnemy>()._headHitBox;
        }
    }
}
