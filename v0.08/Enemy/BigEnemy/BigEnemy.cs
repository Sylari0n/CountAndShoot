using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BigEnemy : MonoBehaviour
{

    [SerializeField] int totalHp = 1;
    [SerializeField] int headHitboxDamage = 1;
    [SerializeField] int chestHitboxDamage = 1;
    [SerializeField] int ballDamage = 1;
    [SerializeField] TMP_Text totalHpText;
    [SerializeField] TMP_Text headHitboxText;
    [SerializeField] TMP_Text chestHitboxText;
    [SerializeField] GameObject _headCol;
    [SerializeField] GameObject _chestCol;
    [SerializeField] public GameObject _playerChecker;

    [HideInInspector] public int tmpTotalHp;
    [HideInInspector] public bool isPlayer = false;

    // true for head, false for body
    [HideInInspector] public bool headOrBody;


    
    

    void Start()
    {
        tmpTotalHp = totalHp;
        headHitboxText.text = headHitboxDamage.ToString();
        chestHitboxText.text = chestHitboxDamage.ToString();
    }

    void Update()
    {
        totalHpText.text = totalHp.ToString();
        DisplayHitDamage();
        DisplayTotalHp();
        MakeGhost();
    }
    void DisplayHitDamage()
    {
        if (tmpTotalHp >= 0)
        {
            if (_headCol.GetComponent<HeadCol>().isHead)
            {
                Debug.Log("Head");
                tmpTotalHp -= ballDamage * headHitboxDamage;
                _headCol.GetComponent<HeadCol>().isHead = false;
                
                // True for HEAD animation
                headOrBody = true;
            }

            else if (_chestCol.GetComponent<ChestCol>().isChest)
            {
                Debug.Log("Chest");
                tmpTotalHp -= ballDamage * chestHitboxDamage;
                _chestCol.GetComponent<ChestCol>().isChest = false;

                // False for BODY animation
                headOrBody = false;
            }
        }
        if (tmpTotalHp < 0)
        {
            tmpTotalHp = 0;
        }
    }

    void DisplayTotalHp()
    {
        if (tmpTotalHp <= 0)
        {
            totalHpText.enabled = false;
            headHitboxText.enabled = false;
            chestHitboxText.enabled = false;
        }
        totalHpText.text = tmpTotalHp.ToString();
    }

    void MakeGhost()
    {
        if (tmpTotalHp <= 0)
        {
            Invoke(nameof(KinematicDelay), 2f);
            Invoke(nameof(GhostDelay), 0.05f);
            gameObject.tag = "null";
        }
    }

    void GhostDelay()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }
    void KinematicDelay()
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }

}
