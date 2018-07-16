using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuControl : HideUI {

    public InventoryItem item;      //存储单击了那个物品的槽
	
    // Use this for initialization
	void Start () {
		
	}

    public void OnUse()
    {
        item.Use(1);
    }
}
