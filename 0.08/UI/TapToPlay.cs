using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToPlay : MonoBehaviour
{
    [SerializeField] GameObject _playerObj;
    [SerializeField] Canvas _controlUi;

    void Start()
    {
        _playerObj.GetComponent<PlayerControls>().isTapped = false;
        _controlUi.enabled = false;
    }

    public void TapToCloseCanvas()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
        _controlUi.enabled = true;
        _playerObj.GetComponent<PlayerControls>().isTapped = true;
    }


}
