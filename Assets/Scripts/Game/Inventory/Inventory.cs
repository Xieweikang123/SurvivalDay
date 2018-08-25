using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public static Inventory _instance;

    public InventoryItem[] inventoryItemsObj;

   // public InventoryItem handHoldItem;
    public InventoryItem clothItem;

    private void Awake()
    {
        _instance = this;

        inventoryItemsObj = GetComponentsInChildren<InventoryItem>();
    }
    // Use this for initialization
    void Start () {
        //   print("执行了");
        AddItems("001", 1);
       // AddItems(6, 1);
        //AddItems(2, 2);
        AddItems("303", 1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //交换两个槽
    static public void Exchange(InventoryItem item1,InventoryItem item2 )
    {
        string tempID = item1.ID;
        int tempCount = item1.Count;

        item1.SetData(item2.ID, item2.Count);
        item2.SetData(tempID, tempCount);
    }

    //得到一个物品
    public void AddItems(string id, int count)
    {
        InventoryItem tempItem = null; //存储一个空槽

        //判断物品是否已经存在
        foreach (InventoryItem obj in  inventoryItemsObj)
        {
            InventoryItem inventoryItem = obj;
            //如果存在，则count++
            if (id == inventoryItem.ID)
            {
                //print("物品已存在k1");
                inventoryItem.Count += count;
                inventoryItem.UpdataCount();
                return;
            }
            //储存第一个遍历到的储存槽
            if (inventoryItem.Count == 0 && tempItem == null)
            {
                tempItem = obj;
                //print("找到一个空槽  ");
            }
        }
        //如果不存在，查看背包是否已经满了
        //如果没满，新建一个item存放物品
        if (tempItem != null)
        {
            //print("设置数据");
            //print(id);

            InventoryItem temp = tempItem;
            //设置数据
            temp.SetData(id,count);
        }
        //否则提示背包已满
        else
        {
            Debug.Log("背包已满");
        }
    }

    //判断物品是否存在
    private bool isExist(string id)
    {
        foreach (InventoryItem obj in inventoryItemsObj)
        {
           // InventoryItem inventoryItem = obj.GetComponent<InventoryItem>();
            if (id == obj.ID)
            {
                return true;
            }
        }
        return false;
    }
}

