using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHeadCollider : MonoBehaviour
{


    public bool isFrontHead = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            isFrontHead = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            isFrontHead = false;
        }
    }

}
