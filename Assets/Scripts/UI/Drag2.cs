using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag2 : Drag {

    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
        ManufactureControl._instance.IsCanManufacture();
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        //把原来的预制作图片清除
        transform.parent.parent.Find("item5").GetComponent<Image>().sprite = Resources.LoadAll<Sprite>("Textures/UI/widgets")[8];
            //Resources.Load("Textures/bag",typeof(Sprite)) as Sprite;

       // ManufactureControl._instance.IsCanManufacture();
        transform.parent.parent.Find("btnManufacture").GetComponent<Button>().enabled = false;
    }
}
