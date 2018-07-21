using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAndHide : MonoBehaviour {

    [SerializeField]
    private GameObject _showAndHideObj;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ShowAndHideUI);
    }

    private void ShowAndHideUI()
    {
        _showAndHideObj.SetActive(!_showAndHideObj.activeInHierarchy);
    }
}
