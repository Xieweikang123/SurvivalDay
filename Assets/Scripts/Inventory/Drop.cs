using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Drop : MonoBehaviour,IDropHandler {

    public virtual void OnDrop(PointerEventData eventData)
    {

        Destroy(GameObject.Find("icon1"));


        GameObject obj = eventData.pointerDrag;

        InventoryItem originalItem = obj.transform.parent.GetComponent<InventoryItem>();

        //一个bug，如果拖拽虚拟摇杆的球到快捷栏时，会报错
        if (originalItem == null) return;

        //不管要拖拽的物品有几个，统统直接交换
        //交换两个槽的信息
        Inventory.Exchange(originalItem, GetComponent<InventoryItem>());
    }

}
