using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CSVReadData : MonoBehaviour {

    public static CSVReadData _instance;

    private Dictionary<int, MaterialsInfo> _dictFood= new Dictionary<int, MaterialsInfo>();
    public Dictionary<string, MaterialsInfo> _dictMaterials = new Dictionary<string, MaterialsInfo>();
    private Dictionary<int, MaterialsInfo> _dictTool = new Dictionary<int, MaterialsInfo>();
    private Dictionary<int, MaterialsInfo> _dictEquipment = new Dictionary<int, MaterialsInfo>();

    private void Awake()
    {
        _instance = this;

        //将csv内容存到字典
        TextAsset txtCSV = Resources.Load("materialsCSV") as TextAsset;
        string[] lines = txtCSV.ToString().Split('\n');

        for(int i = 1; i < lines.Length; i++)
        {
            //得到一行中的每一项
            string[] items = lines[i].Split(',');
            MaterialsInfo info=new MaterialsInfo();
            info.id = items[0];
            info.name = items[1];
            info.type = items[2];
            info.iconName = items[3];
            info.describe = items[4];

            _dictMaterials.Add(info.id, info);
        }
        print(_dictMaterials["303"].name);
    }
}
public struct MaterialsInfo
{
    public string id;
    public string name;
    public string type;
    public int addEnergy;
    public string iconName;
    public string describe;
}
