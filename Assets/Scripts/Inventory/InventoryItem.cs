using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{

    public string ID = "";

    [SerializeField]
    private int count = 0;

    private  MaterialsInfo info = new MaterialsInfo();
    //public GameObject menuObj;

    private Text countTxt;

    public int Count
    {
        get
        {
            return count;
        }

        set
        {
            count = value;
          
            UpdataCount();
        }
    }

    private void Awake()
    {
        countTxt = transform.Find("icon").GetComponentInChildren<Text>();

        //countTxt = GetComponentInChildren<Text>();
    }
    // Use this for initialization
    void Start()
    {
        //测试
        //SetIcon();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetData(string id, int count)
    {

        if (id == "")
        {
            ClearData();
            return;
        }
        this.ID = id;
        this.Count = count;

        //print(id);

       
       // info = InventoryList._instance.ReadXml(ID);
        info = CSVReadData._instance._dictMaterials[ID];

        transform.Find("icon").gameObject.SetActive(true);
        transform.Find("icon").gameObject.GetComponent<Image>().sprite = Resources.Load("Textures/" + info.iconName, typeof(Sprite)) as Sprite;
        //GetComponentInChildren<Image>().sprite = Resources.Load("Textures/" + info.iconName, typeof(Sprite)) as Sprite;

        


        //print("setIcon");
        //设置数量
        UpdataCount();
    }

    //设置数量
    public void UpdataCount()
    {
        if (Count <= 0)
        {
            //countTxt.enabled = false;
            ClearData();
        }
        else
        {
            countTxt.text = Count.ToString();
            if (countTxt.enabled == false)
            {
                countTxt.enabled = true;
            }
        }
    }

    //使用物品
    public void Use()
    {
        Use(1);
    }
    public void Use(int useNum=1)
    {
        print("使用物品");
        
        //如果id为0，则返回
        if (ID == "")
            return;

        GameObject objHint = GameObject.Find("UI").transform.Find("hint").gameObject;

        //根据物品的类型,产生物品的功效
        switch (info.type)
        {
            case "Food":
                objHint.SetActive(true);

                objHint.GetComponent<Text>().color = Color.black;
                objHint.GetComponent<Text>().text = "你使用了 "+info.name+" ,增加了 <color=red><b>"+info.addHungry+"</b></color> 点能量";
                
               
                //  print("增加了" + info.addEnergy + "点能量");
                break;
            case "Torch":
       
                objHint.SetActive(true);

                //如果不到晚上的话，不使用火把,timePeriod>300时使用
                if (TimeSystem._instance.timePeriod>125&&TimeSystem._instance.timePeriod<500)
                {
                   
                    objHint.GetComponent<Text>().text = "生存不易,还是等晚上再使用吧";
                  
                   // print("还是等晚上再使用吧");
                    return;
                }
                objHint.GetComponent<Text>().text = "你使用了火把";

                //将day隐藏  将TorchNight显示
                GameObject.FindGameObjectWithTag("Player").transform.Find("day").gameObject.SetActive(false);
                GameObject.Find("environment").transform.Find("TorchNight").gameObject.SetActive(true);
              
                break;
            case "Material":
     
                objHint.SetActive(true);
                //如果是材料，不使用
                objHint.GetComponent<Text>().text = "这是材料，不能使用的";
                return;
            case "Hand":    //手里拿的

                print("使用稿子");
                return;
            case "Hoe": //锄头
                print("使用了锄头");

                PlayerState playerState = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>();
                GameObject player = playerState.gameObject;

                Vector2 v2= playerState.TowardPos();


                GameManager._instance.mapTiles[(int)v2.x, (int)v2.y].GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("Textures/terrain")[3];

                return;
            default:
                //print("未知物品类型");
                objHint.GetComponent<Text>().text = "未知物品类型";
                break;
        }

        this.Count -= useNum;
        UpdataCount();

        //如果此物品用完了，隐藏物品介绍面板和操作面板
        if (this.Count == 0)
        {
            transform.root.Find("describe").gameObject.SetActive(false);
        }

     
    }

    //清空数据
    public void ClearData()
    {
        ID = "";
        count = 0;

        countTxt.enabled = false;

        transform.Find("icon").gameObject.SetActive(false);
    }

    //当单击了物品
    //显示操作面板/显示物品简介面板
    public void OnClickIcon()
    {
        GameObject desObj = transform.root.Find("describe").gameObject;

        desObj.SetActive(true);

        //把该物品的InventoryItem赋给describe面板

        Vector3 v3 = Input.mousePosition;
        v3 -= new Vector3(Screen.width / 2-70, Screen.height / 2+80, 0);
        
        v3 += new Vector3(Screen.width / 2 - 1150, Screen.height / 2 - 350, 0);
        desObj.transform.localPosition = v3;

        MaterialsInfo info = new MaterialsInfo();
        //info = InventoryList._instance.ReadXml(this.ID);
        info = CSVReadData._instance._dictMaterials[ID];
        //print(info.describe);
        desObj.GetComponentInChildren<Text>().text = info.describe;
    }
}
