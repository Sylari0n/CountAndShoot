using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    [SerializeField] GameObject _basicEnemyObj;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hello");
            _basicEnemyObj.GetComponent<BasicEnemy>().isPlayer = true;
        }
    }
}
