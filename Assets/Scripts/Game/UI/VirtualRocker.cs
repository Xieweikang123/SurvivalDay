using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualRocker : MonoBehaviour,IDragHandler,IEndDragHandler {

    public GameObject virtualRocker;

    public GameObject movePoint;

    private bool click;

    private bool isSetPos=false;    //用于虚拟球定位

    private Vector3 dir;
    private Vector3 normalPosition;

    private float r;//虚拟球运动半径

    private Action<Vector3> playerMove;

    private void Start()
    {
        normalPosition = virtualRocker.transform.localPosition;

        r = virtualRocker.GetComponent<RectTransform>().rect.width / 2;

        if (playerMove == null)
            playerMove = PlayerMove.Instance.Move;
    }

    private void FixedUpdate()
    {
        if (click) playerMove(dir);
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        Vector3 point;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(movePoint.GetComponent<RectTransform>(), eventData.position, Camera.main, out point))
        {
            movePoint.transform.position = point;
            dir = point - virtualRocker.transform.position;


            //限制虚拟球运动范围
            if (Vector3.Distance(movePoint.transform.localPosition, Vector3.zero) >= r)
            {
                movePoint.transform.localPosition = dir.normalized * r;
               // print(dir.normalized * r);
            }

            click = true;

            //首次定位
            if (!isSetPos)
            {
                isSetPos = true;
                virtualRocker.transform.position = point;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //虚拟球复位
        virtualRocker.transform.localPosition = normalPosition;

        movePoint.transform.localPosition = Vector2.zero;
        click = false;
        isSetPos = false;
    }
}
