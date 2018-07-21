using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Drop : MonoBehaviour,IDropHandler {

    public virtual void OnDrop(PointerEventData eventData)
    {
       // print("onDrop");



        Destroy(GameObject.Find("icon1"));


        GameObject obj = eventData.pointerDrag;

        InventoryItem originalItem = obj.transform.parent.GetComponent<InventoryItem>();
      
        //修复bug,当拖动虚拟摇杆到快捷栏时，会报错
        if (originalItem == null)
            return;

        //不管要拖拽的物品有几个，统统直接交换
        //交换两个槽的信息
        Inventory.Exchange(originalItem, GetComponent<InventoryItem>());

        ////如果要拖拽的物品只有一个的话，就不需要选择数量了，而是直接拖拽
        //if (originalItem.Count == 1)
        //{
        //    //交换两个槽的信息
        //    Inventory.Exchange(originalItem, GetComponent<InventoryItem>());
        //    //将原来的信息清空
        //    originalItem.ClearData();

        //    return;
        //}


        ////显示数量面板
        //GameObject countPanel = transform.root.Find("moveCountPanel").gameObject;
        //countPanel.SetActive(true);
        //countPanel.GetComponent<moveCountControl>().originalItem = originalItem;
        //countPanel.GetComponent<moveCountControl>().aimItem = GetComponent<InventoryItem>();

    }

}
