using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class InventoryList : MonoBehaviour
{
    public static InventoryList _instance;

    private void Awake()
    {
        _instance = this;
    }
    // Use this for initialization
    void Start()
    {
        //materialsInfo info = new materialsInfo();
        //info = ReadXml(1);
        //Debug.Log(info);
        //Debug.Log(info.iconName);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public MaterialsInfo1 ReadXml(int id)
    {
        //Debug.Log("read");

        MaterialsInfo1 info=new MaterialsInfo1();

        XmlDocument playerXml = new XmlDocument();

        ////如果是安卓平台
        //if (Application.platform == RuntimePlatform.Android)
        //{
        //    playerXml.Load(Application.streamingAssetsPath + "/materials.xml");

        //}
        //else
        //    playerXml.Load(".\\Assets\\materials.xml");

        // playerXml.Load(Application.streamingAssetsPath + "/materials.xml");

        playerXml.LoadXml(Resources.Load("materials").ToString());

        //GameObject.Find("note").GetComponent<UnityEngine.UI.Text>().text = Application.persistentDataPath;

        XmlElement players = playerXml.DocumentElement;//获取根元素  
        foreach (XmlNode player in players.ChildNodes)//遍历所有子节点  
        {
            foreach (XmlNode node in player.ChildNodes)
            {
                XmlElement xe = (XmlElement)node;

                switch (xe.Name)
                {
                    case "id":
                        info.id = int.Parse(xe.InnerText);
                        break;
                    case "name":
                        info.name = xe.InnerText;
                        break;
                    case "type":
                        info.type = xe.InnerText;
                        break;
                    case "addEnergy":
                        info.addEnergy = int.Parse(xe.InnerText);
                        break;
                    case "iconName":
                        info.iconName = xe.InnerText;
                        break;
                    case "describe":
                        info.describe = xe.InnerText;
                        break;
                    default:
                        break;
                }
            }
            //如果找到目标，则返回
            if (info.id == id)
                return info;
        }

        return info;
    }
}
public struct MaterialsInfo1
{
    public int id;
    public string name;
    public string type;
    public int addEnergy;
    public string iconName;
    public string describe;
}