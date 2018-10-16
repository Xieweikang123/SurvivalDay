using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public struct saveInfo
{
    public string name;
    public int level;
}
public class Save : MonoBehaviour
{

    public Text textName;
    public Text textLevel;

    public Text note;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //存储数据
    public void SaveData()
    {
        //定义存档路径
        string dirpath = Application.persistentDataPath + "/Save";

        print(Application.persistentDataPath);

        //创建存档文件夹
        IOHelper.CreateDirectory(dirpath);
        //定义存档文件路径
        string filename = dirpath + "/GameData.sav";

        saveInfo info = new saveInfo();

        info.name = textName.text;
        if (!(textLevel.text == ""))
            info.level = int.Parse(textLevel.text);

        IOHelper.SetData(filename, info);

        print("存储成功");
    }

    public void GetData()
    {
        //定义存档路径
        string dirpath = Application.persistentDataPath + "/Save";
        //定义存档文件路径
        string filename = dirpath + "/GameData.sav";
        saveInfo info =(saveInfo)IOHelper.GetData(filename, typeof(saveInfo));

        string str = "";
        str += "玩家名字："+info.name + "\n\n\n";
        str += "玩家等级："+info.level;

        note.text = str;

        print(info.name);
        print(info.level.ToString());
    }
}
