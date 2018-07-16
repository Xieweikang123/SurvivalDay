using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop2 : Drop
{

    public override void OnDrop(PointerEventData eventData)
    {
       // print("ondrop");
        base.OnDrop(eventData);
        ManufactureControl._instance.IsCanManufacture();
    }
}