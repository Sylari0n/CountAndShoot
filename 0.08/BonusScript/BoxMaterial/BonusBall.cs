using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBall : MonoBehaviour
{
    
    [SerializeField] private float _dragZ = 0.2f;

    public int ballInBag = 0;

    void Update()
    {
        DragZ();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<BallScript>().totalBallCount++;
            Destroy(gameObject);
            ballInBag += 3;
        }
    }

    void DragZ()
    {
        if (gameObject.GetComponent<Rigidbody>().velocity.z != 0)
            {
                gameObject.GetComponent<Rigidbody>().velocity *= 1f - _dragZ;
            }
    }
}
