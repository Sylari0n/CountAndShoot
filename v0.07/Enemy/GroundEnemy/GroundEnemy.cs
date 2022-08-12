using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GroundEnemy : MonoBehaviour
{
    [SerializeField] int _totalHp;
    [SerializeField] public int _headHitBox;
    [SerializeField] public int _chestHitbox;
    [SerializeField] private GameObject _head;
    [SerializeField] private GameObject _chest;
    [SerializeField] private GameObject _headCheck;
    [SerializeField] private float _enemyDisappearTime;
    [SerializeField] TMP_Text _totalHpText;
    [SerializeField] TMP_Text _headHitboxText;
    [SerializeField] TMP_Text _chestHitboxText;

    [HideInInspector] public int tmpTotalHp;

    
    void Start()
    {
        _headHitboxText.text = _headHitBox.ToString();
        _chestHitboxText.text = _chestHitbox.ToString();
        tmpTotalHp = _totalHp;
    }


    void Update()
    {
        _totalHpText.text = tmpTotalHp.ToString();
        KinematicSwitch();
        LifeChecker();
        DisplayHeadCheck();

        Debug.Log("is head: " + _head.GetComponent<Head>().isHead);
    }



    public void LifeChecker()
    {
        if (tmpTotalHp <= 0)
        {
            tmpTotalHp = 0;
            Invoke(nameof(isTriggerSwitch), _enemyDisappearTime);
        }
    }

    void isTriggerSwitch()
    {
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }

    // void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.tag == "Ball")
    //     {
    //         other.gameObject.tag = "null";
    //         // other.gameObject.GetComponent<SphereCollider>().isTrigger = true;
    //     }

    //     // if (other.gameObject.tag == "Player")
    //     // {
    //     //     Destroy(other.gameObject);
    //     //     FindObjectOfType<GameOverScreen>().isDead = true;
    //     // }
    // }
    
    void KinematicSwitch()
    {
        if (_headCheck.GetComponent<CheckHeadCollider>().isFrontHead)
        {
            Debug.Log("Third");
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
            
        if (_headHitBox >= _chestHitbox)
        {
            if (tmpTotalHp <= _chestHitbox)
            {
                Debug.Log("first");
                Invoke(nameof(Kinematic), 0.05f);
            }
            return;
        }

        if (_chestHitbox >= _headHitBox)
        {
            if (tmpTotalHp <= _headHitBox)
            {
                Debug.Log("Second");
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }
            return;
        }
        
        
    }

    void Kinematic()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    void DisplayHeadCheck()
    {
        if (tmpTotalHp == _headHitBox || _headHitBox >= tmpTotalHp)
        {
            _headCheck.SetActive(true);
        }
        else
        {
            _headCheck.SetActive(false);
        }
    }
}
