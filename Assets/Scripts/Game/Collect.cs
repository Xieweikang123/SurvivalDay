using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Collect : MonoBehaviour
{

    public GameObject getUI;
    public GameObject panelBagObj;
    public Slider collectionSlider;

    public Button btnInteraction;

    private GameObject waitForCollectObj = null;

    private UnityAction unityAction;

    private void Awake()
    {
        //让panelBag先激活
        //GameObject obj = GameObject.Find("panelBag");
    
        // panelBagObj.SetActive(true);
        //panelBagObj.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        waitForCollectObj = collision.gameObject;

        //根据玩家触碰到物体的标签，判断行为
        switch (collision.tag)
        {
            case "Goods":
                //  getUI.SetActive(true);
                //  getUI.GetComponentInChildren<Text>().text = "拾取";
                break;
            //农作物
            case "Crop":
                //  getUI.SetActive(true);
                waitForCollectObj = collision.gameObject;

                //  getUI.GetComponentInChildren<Text>().text = "收获";
                break;
            //碰到了石头
            case "Stone":
                print("碰到了石头");
                break;

            default: return ;
        }
        //降低透明度
        waitForCollectObj.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);

        //给交互按钮动态添加OnClick监听
        unityAction = new UnityAction(PickUp);
        btnInteraction.onClick.AddListener(unityAction);
    }


    private void OnTriggerExit2D (Collider2D collision)
    {
        if (waitForCollectObj == null)
            return;

        //提高透明度
        waitForCollectObj.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);

        //如果玩家离开
        getUI.SetActive(false);
        waitForCollectObj = null;

        //解绑监听
        btnInteraction.onClick.RemoveListener(unityAction);
       // unityAction -= PickUp;
    }


    //get按钮拾取
    public void PickUp()
    {
        Good good = waitForCollectObj.GetComponent<Good>();

        StartCoroutine(waitThenCollect(good));
    }
    IEnumerator waitThenCollect(Good good)
    {
        //在获取物品前，先判断待拾取的是什么物体，如果是萝卜之类的，不管玩家是否使用工具，都可以拾取。    如果是石块之类的，则要先判断玩家是否使用了相应的工具，如果是的话才能拾取

        //通过good的id得到物体的信息
        MaterialsInfo info=new MaterialsInfo();
        try { 
             info = CSVReadData._instance._dictMaterials[good.id];
        }
        catch
        {
            print("不能从字典里找到此id");
        }
        //判断物体类型
        switch (info.type)
        {
            //如果是石头
            case "Stone":
                //判断玩家是否使用稿子
                if (ShortCuts.holdObjItem==null||ShortCuts.holdObjItem.ID != "7")
                {
                    print("请使用镐子");
                    yield break;
                }

                break;

            default:
                break;
        }

        //激活slider
        collectionSlider.gameObject.SetActive(true);

        //玩家的原始位置,如果原始位置与现位置的距离大于0.1f 则视为玩家移动，取消收集
        Vector2 originalPos = transform.position;

        for (float f = 0; f < good.collectionTime + 0.1f; f += 0.1f)
        {
            //如果原始位置与现位置的距离大于0.1f 则视为玩家移动，取消收集
            if (Vector2.Distance(originalPos, transform.position) > 0.1f)
            {
                collectionSlider.gameObject.SetActive(false);
                yield break;
            }
            //slider计算公式  1/good.collectionTime*f
            collectionSlider.value = 1 / good.collectionTime * f;

            //print(f);
            //yield return null;

            yield return new WaitForSeconds(0.1f);
        }

        collectionSlider.gameObject.SetActive(false);

        //将物品放入背包
        Inventory._instance.AddItems(good.id, good.count);

        //销毁被捡物品
        Destroy(waitForCollectObj);
    }
}
