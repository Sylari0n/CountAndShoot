using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FloorText : MonoBehaviour
{
    [SerializeField] TMP_Text floorText;

    void Start()
    {
        floorText.text = "Level " + SceneManager.GetActiveScene().buildIndex;
    }
}
