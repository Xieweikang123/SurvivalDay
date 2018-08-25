using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    private GameObject dragIcon;

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        //print("开始拖拽");
        //dragIcon = Instantiate(this.gameObject,this.transform.parent);

        //代替品实例化
        dragIcon = new GameObject("icon1");
        dragIcon.transform.SetParent(GameObject.Find("UI").transform, false);
        dragIcon.AddComponent<RectTransform>();
        var img = dragIcon.AddComponent<Image>();
        img.sprite = this.GetComponent<Image>().sprite;

        //防止拖拽结束时，代替品挡住了准备覆盖的对象而使得 OnDrop（） 无效
       CanvasGroup group = dragIcon.AddComponent<CanvasGroup>();
        group.blocksRaycasts = false;


    }

    public void OnDrag(PointerEventData eventData)
    {
        //并将拖拽时的坐标给予被拖拽对象的代替品
        Vector3 pos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(dragIcon.GetComponent<RectTransform>(),
            eventData.position, Camera.main, out pos))
        {
            dragIcon.transform.position = pos;
            //print("drag");
        }
    }

    //这个函数是被拖拽到的那个物体调用的
    public virtual void OnDrop(PointerEventData eventData)
    {
        //print("onDrop");
        Destroy(GameObject.Find("icon1"));

        var OriginalObj = eventData.pointerDrag;    //拖动的物体

        if (OriginalObj == gameObject)
        {
            print("拖到了自身");
            return;
        }
        //print("onDrop");

        //交换物品信息
        //print("交换");
        InventoryItem aimItem = transform.parent.GetComponent<InventoryItem>();
        InventoryItem originalItem = OriginalObj.transform.parent.GetComponent<InventoryItem>();

        //如果两物品同id，则合并
        if (originalItem.ID == aimItem.ID)
        {
            //print("id same");
            originalItem.Count += aimItem.Count;
            aimItem.ClearData();
        }
       
        Inventory.Exchange(originalItem, aimItem);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //print("onEndDrag");
        Destroy(dragIcon);
    }
}
