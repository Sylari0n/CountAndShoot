using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyState : MonoBehaviour
{
    [SerializeField] private GameObject _headCol;
    [SerializeField] private GameObject _chestCol;
    [SerializeField] private GameObject _playerObj;


    void Start()
    {
        _eAnimator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        IdleToDeath();
        IdleToSlap();
    }

    void IdleToDeath()
    {
        if (gameObject.GetComponent<BasicEnemy>().tmpTotalHp == 0)
        {
            if (gameObject.GetComponent<BasicEnemy>().headOrBody == true)
            {
                _eAnimator.SetTrigger("IdleToDeathHead");
            }

            else if(gameObject.GetComponent<BasicEnemy>().headOrBody == false)
            {
                _eAnimator.SetTrigger("IdleToDeathBody");
            }
        }
    }

    void IdleToSlap()
    {
        if (gameObject.GetComponent<BasicEnemy>().isPlayer)
        {
            _eAnimator.SetTrigger("IdleToSlap");
        }
    }




    private Animator _eAnimator;
}
