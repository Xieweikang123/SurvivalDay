using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ShortCuts : MonoBehaviour {

    public static InventoryItem holdObjItem;   //当前持有物

    private Outline lastOutline;    //上一个outline

    public Button btnInteraction;   //交互按钮

    private UnityAction unityAction;

    //当鼠标（手指）点击了快捷栏的物品图标
    public void OnClickShortCutIcon()
    {

        //判断lastOutline是否为空，如果为空，将这个物体的outline赋给lastoutline；否则，将lastoutline的enable设为false，然后将这个物体的outline赋给lastoutline

        GameObject obj = EventSystem.current.currentSelectedGameObject;

        //得到outline
        Outline currentOutline;
        if (obj.GetComponent<Outline>() == null)
        {
            currentOutline = obj.GetComponentInParent<Outline>();
        }
        else
            currentOutline = obj.GetComponent<Outline>();

       // print(obj);

        //如果不是初次选择
        if (lastOutline != null)
        {
            lastOutline.enabled = false;
        }

        //这是一个bug的临时修复方法,玩家在移动的时候，手指实际所点位置和输出位置不同
        if (currentOutline == null)
            return;

        lastOutline = currentOutline;
        currentOutline.enabled = true;

        //选择后，判断选的物品
        AfterSelect();
    }

    private void AfterSelect()
    {
        //得到inventoryItem
         holdObjItem = lastOutline.gameObject.GetComponent<InventoryItem>();

        //先删除之前的监听
        if(unityAction!=null)
            btnInteraction.onClick.RemoveListener(unityAction);

        //给交互按钮一个监听
        unityAction = new UnityAction(holdObjItem.Use);
        btnInteraction.onClick.AddListener(unityAction);
    }
    
}
