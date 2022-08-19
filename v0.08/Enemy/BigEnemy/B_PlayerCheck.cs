using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_PlayerCheck : MonoBehaviour
{
    [SerializeField] GameObject _bigEnemyObj;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hello");
            _bigEnemyObj.GetComponent<BigEnemy>().isPlayer = true;
        }
    }
}
