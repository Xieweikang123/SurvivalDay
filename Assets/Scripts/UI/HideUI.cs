using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HideUI : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (Application.platform == RuntimePlatform.Android)
            {
                //安卓手机适用
                if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    // print(EventSystem.current.currentSelectedGameObject);

                    if (EventSystem.current.currentSelectedGameObject == null || EventSystem.current.currentSelectedGameObject.tag != "Menu")
                        gameObject.SetActive(false);
                }
            }
            else if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    // print(EventSystem.current.currentSelectedGameObject);

                    if (EventSystem.current.currentSelectedGameObject == null || EventSystem.current.currentSelectedGameObject.tag != "Menu")
                        gameObject.SetActive(false);
                }
            }


        }
    }
}
