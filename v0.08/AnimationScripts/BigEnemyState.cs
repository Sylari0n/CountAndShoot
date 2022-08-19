using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyState : MonoBehaviour
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
        if (gameObject.GetComponent<BigEnemy>().tmpTotalHp <= 0)
        {
            if (gameObject.GetComponent<BigEnemy>().headOrBody == true)
            {
                _eAnimator.SetTrigger("IdleToDeathHead");
            }

            else if(gameObject.GetComponent<BigEnemy>().headOrBody == false)
            {
                _eAnimator.SetTrigger("IdleToDeathBody");
            }
        }
    }

    void IdleToSlap()
    {
        if (gameObject.GetComponent<BigEnemy>().isPlayer)
        {
            _eAnimator.SetTrigger("IdleToSlap");
        }
    }




    private Animator _eAnimator;
}
