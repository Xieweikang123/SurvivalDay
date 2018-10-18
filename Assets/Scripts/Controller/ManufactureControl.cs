using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManufactureControl : MonoBehaviour {

    public static ManufactureControl _instance;
   // private Dictionary<int, int> idAndCountDic = new Dictionary<int, int>();

    [SerializeField]
    private InventoryItem[] items;  //包含的四个制作槽
    //private int totalID=0;        //id总和

    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        items = GetComponentsInChildren<InventoryItem>();
    }

    //合并两项
    public void CommonThem()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].ID == "")
                continue;

            for (int j = i + 1; j < items.Length; j++)
            {
                //print("i:" + i);
                //print("j:" + j);

                if (items[i].ID == items[j].ID)
                {
                    items[i].Count += items[j].Count;
                    items[j].ClearData();
                }
            }
        }
    }


    //判断是否可以合成
    public  void IsCanManufacture()
    {
        ////print("是否可以合成  ");

        ////先把相同的项合并
        ////合并相同id的槽
        //CommonThem();

        //totalID = 0;
        ////算出总id
        //foreach(InventoryItem tempItem in items)
        //{
        //    //totalID += tempItem.ID;
        //}

        ////print("totalID" + totalID);

        //idAndCountDic.Clear();

        ////把原来的预制作图片清除
        //// transform.Find("item5").GetComponent<Image>().sprite = Resources.Load("Textures/UI/widgets_8", typeof(Sprite)) as Sprite;
        //transform.Find("item5").GetComponent<Image>().sprite = Resources.LoadAll<Sprite>("Textures/UI/widgets")[8];

        ////设置button不可用
        //transform.Find("btnManufacture").GetComponent<Button>().enabled = false;


        ////判断原料是否足够
        //switch (totalID)
        //{
            
        //    case 2: case 3: return;  

        //    case 5: //火把,需要两个木材(id:3)和一个煤矿(id:2)

        //        //print("5");

        //        foreach (InventoryItem tempItem in items)
        //        {
        //            //必须是合成的材料，否则return
        //            if (tempItem.ID == 3 || tempItem.ID == 2||tempItem.ID==0)
        //            {
        //                if (tempItem.ID == 3)
        //                {
        //                    if (tempItem.Count < 2)
        //                        return;
        //                }
        //            }
        //            else
        //                return;
        //        }
        //        idAndCountDic.Add(2, 1);
        //        idAndCountDic.Add(3, 2);
        //        break;
        //    default:  return;
        //}

        ////设置button可用
        //transform.Find("btnManufacture").GetComponent<Button>().enabled = true;
       
        ////更改待制作的物品的图标
        //MaterialsInfo info = CSVReadData._instance._dictMaterials[totalID];

        ////print(info.iconName);
        //transform.Find("item5").GetComponent<Image>().sprite = Resources.Load("Textures/" + info.iconName, typeof(Sprite)) as Sprite;
    }

    //制作按钮，相应
    public void OnManufactureClick()
    {
        ////减去相应数量的原材料
        //foreach(KeyValuePair<int,int> kvp in idAndCountDic)
        //{
        //    foreach(InventoryItem item in items)
        //    {
        //        if (item.ID == kvp.Key)
        //        {
        //            ////数量不够就不能继续制作了
        //            //if (item.Count == 0)
        //            //    return;
        //            item.Count -= kvp.Value;
        //        }
        //    }
        //}
        ////将制作出的物品加入背包
        //Inventory._instance.AddItems(totalID, 1);
        //IsCanManufacture();
    }
}
