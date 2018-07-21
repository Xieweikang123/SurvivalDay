using UnityEngine;
using UnityEditor;
using System.Xml;
using System.IO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
public class ExportXml : EditorWindow
{
    //拷贝目标路径
    private static string copyDataPath = Application.dataPath + "/Xml/";

    [MenuItem("ExportXmlLanuguage/加密导出XML/中文")]
    public static void EncryptXmlCN()
    {
        string choosepath = "ChinaData";
        string targetpath = Application.dataPath + "/Resources/Data";

        if (!Directory.Exists(targetpath))
        {
            Directory.CreateDirectory(targetpath);
        }
        ExportEncryptXml(choosepath,targetpath);
    }

    private static void ExportEncryptXml(string choosepath,string targetpath)
    {
        string[] sourceFiles = Directory.GetFiles(copyDataPath + choosepath);
        if (EditorUtility.DisplayDialog("加密XML", "是否加密XML?", "是", "否"))
        {
            foreach (string xmlFile in sourceFiles)
            {
                string extensionName = Path.GetExtension(xmlFile);
                string targetFileName = Path.GetFileName(xmlFile);
                //string targetFile = Path.Combine(targetpath,targetFileName);
                if (extensionName.Equals(".xml"))
                {
                    //读出文件流 为加密做准备
                    StreamReader streamReader = File.OpenText(xmlFile);
                    string dataString = streamReader.ReadToEnd();
                    streamReader.Close();

                    string target = Encrypt(dataString);
                    StreamWriter writer;
                    writer = File.CreateText(targetpath + "/" + targetFileName);
                    writer.Write(target);
                    writer.Close();
                }
            }
        }
    }
    //加密
    private static string Encrypt(string toE)
    {
        byte[] keyArray = UTF8Encoding.UTF8.GetBytes(Config.EncryptKey);
        RijndaelManaged rDel = new RijndaelManaged();
        rDel.Key = keyArray;
        rDel.Mode = CipherMode.ECB;
        rDel.Padding = PaddingMode.PKCS7;
        ICryptoTransform cTransform = rDel.CreateEncryptor();

        byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toE);
        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray,0,toEncryptArray.Length);

        return Convert.ToBase64String(resultArray,0,resultArray.Length);
    }
}
