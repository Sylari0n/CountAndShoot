using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCol : MonoBehaviour
{
    
    public bool isHead = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            isHead = true;
            other.gameObject.tag = "null";
        }
    }

    // void OnTriggerExit(Collider other)
    // {
    //     if (other.gameObject.tag == "Ball" || other.gameObject.tag == "null")
    //     {
    //         isHead = false;
    //     }
    // }
}
