using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CSVReadData : MonoBehaviour {

    public static CSVReadData _instance;

    public Dictionary<int, MaterialsInfo> _dictMaterials = new Dictionary<int, MaterialsInfo>();


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
            info.name = items[1];
            info.type = items[2];
            info.iconName = items[3];
            info.describe = items[4];

            _dictMaterials.Add(i, info);
        }
        //MaterialsInfo info1 = new MaterialsInfo();
        //print(_dictMaterials.TryGetValue(1, out info1));
        //print(info1.name);
    }
}
public struct MaterialsInfo
{
  //  public int id;
    public string name;
    public string type;
    public int addEnergy;
    public string iconName;
    public string describe;
}
