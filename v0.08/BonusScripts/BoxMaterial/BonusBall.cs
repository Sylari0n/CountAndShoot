using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBall : MonoBehaviour
{
    
    [SerializeField] private float _dragZ = 0.2f;

    public int ballInBag = 0;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

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

        // gameObject.GetComponent<Rigidbody>().velocity *= 1f - _dragZ;
        rb.velocity = new Vector3(rb.velocity.x ,rb.velocity.y ,1f * _dragZ);
    }


    private Rigidbody tmpVelocity;
    private Rigidbody rb;
}
