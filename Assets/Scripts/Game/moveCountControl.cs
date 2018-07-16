using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class moveCountControl : MonoBehaviour {

    public InventoryItem originalItem;
    public InventoryItem aimItem;

    public void OnInputFieldValueChange()
    {
        InputField inputfield = GameObject.Find("InputField").GetComponent<InputField>();

        if (int.Parse(inputfield.text) > originalItem.Count)
            inputfield.text = originalItem.Count.ToString();
    }

    public void OnBtnOK()
    {
        int count = int.Parse(GetComponentInChildren<InputField>().text);

        GetComponentInChildren<InputField>().text = 1.ToString();

        aimItem.SetData(originalItem.ID, count);
        originalItem.Count -= count;

        //ManufactureControl._instance.CommonThem();
        ManufactureControl._instance.IsCanManufacture();
        //交换两个槽的信息
        //Inventory.Exchange(originalItem, GetComponent<InventoryItem>());

    }
}
