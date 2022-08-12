using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FnishSpotScript : MonoBehaviour
{
    
    
    [SerializeField] GameObject _playerObj;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // FindObjectOfType<PlayerControls>().isFnished = true;
            _playerObj.GetComponent<PlayerControls>().isFnished = true;
        }
    }

}
