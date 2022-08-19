using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCol : MonoBehaviour
{

    public bool isChest = false;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            isChest = true;
            other.gameObject.tag = "null";
        }
    }

    // void OnTriggerExit(Collider other)
    // {
    //     if (other.gameObject.tag == "Ball" || other.gameObject.tag == "null")
    //     {
    //         isChest = false;
    //     }
    // }

}
