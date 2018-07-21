using Assets.Scripts.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI操作模块
/// </summary>

public class UIOperation : MonoBehaviour {

    /// <summary>
    /// 手指拖动时
    /// 作者：
    /// </summary>
    public void OnFingerDrag()
    {
        //拖动时获取物品信息
        //GetItemInfo();
    }

    /// <summary>
    ///获取物品信息
    /// 作者：
    /// </summary>
    public ItemBase GetItemInfo(ItemBase itemBase)
    {
        ItemBase get = new ItemBase();
        get.ItemID = itemBase.ItemID;
        return get;
    }

}
