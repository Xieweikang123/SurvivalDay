using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class MapMaker  {
    public static int rows=5;
    public static int cols=5;
    public static UnityEngine.Object GrassLand_O;
    public static UnityEngine.GameObject GrassLand;
    //草地
    [MenuItem("Assets/MapMaker/GrassSpawn")]
    public static void GrassSpawn()
    {
        
        GrassLand=  (Resources.Load("Floor/Grass", typeof(GameObject)))as GameObject;
        //GrassLand = GrassLand_O;
        //  GameObject MapBlock_Grass = new GameObject("MapBlock_Grass");
        GameObject map = new GameObject("Grass");
        Vector2 BornPoint = new Vector2(0, 0);

        for (int i = Convert.ToInt32(BornPoint.x); i < Convert.ToInt32(BornPoint.y) + rows; i++)
        {

            for (int j = Convert.ToInt32(BornPoint.y); j < Convert.ToInt32(BornPoint.y) + cols; j++)
            {
                Common.FloorSpawn(GrassLand, i, j,map);
            }

        }


    }
    //土地
    [MenuItem("Assets/MapMaker/SoilSpawn")]
    public static void LandSpawn()
    {
        GrassLand = (Resources.Load("Floor/Soil", typeof(GameObject))) as GameObject;  
        GameObject map = new GameObject("Soil");
        Vector2 BornPoint = new Vector2(0, 0);

        for (int i = Convert.ToInt32(BornPoint.x); i < Convert.ToInt32(BornPoint.y) + rows; i++)
        {
            for (int j = Convert.ToInt32(BornPoint.y); j < Convert.ToInt32(BornPoint.y) + cols; j++)
            {  
                Common.FloorSpawn(GrassLand, i, j, map);        
            }
        }

    }
    //沙
    [MenuItem("Assets/MapMaker/SandSpawn")]
    public static void SandSpawn()
    {
      
        GrassLand = (Resources.Load("Floor/Sand", typeof(GameObject))) as GameObject;
        //GrassLand = GrassLand_O;
        //  GameObject MapBlock_Grass = new GameObject("MapBlock_Grass");
        GameObject map = new GameObject("Sand");
        Vector2 BornPoint = new Vector2(0, 0);

        for (int i = Convert.ToInt32(BornPoint.x); i < Convert.ToInt32(BornPoint.y) + rows; i++)
        {

            for (int j = Convert.ToInt32(BornPoint.y); j < Convert.ToInt32(BornPoint.y) + cols; j++)
            {
                ////如果是边界
                //if (i == 0 || j == 0 || i == Convert.ToInt32(BornPoint.x) + rows || j == Convert.ToInt32(BornPoint.y + cols))
                //{
                //    //UnityEngine.Object goLand = Resources.Load("Floor/BoardLand", typeof(GameObject));
                //    // mapland.Add(GameObject.Instantiate(goLand, new Vector3(i, j, 0), Quaternion.identity,Map.transform) as GameObject);
                //    Debug.Log(i);
                //    Debug.Log(j);
                //    continue;
                //}
                //生成草地

                Common.FloorSpawn(GrassLand, i, j, map);
                //Instantiate(GrassLand, new Vector3(i, j, 0), Quaternion.identity, MapBlock_Grass.transform);

            }

        }


    }
    //海
    [MenuItem("Assets/MapMaker/SeaFloor")]
    public static void SeaSpawn()
    {
      
        GrassLand = (Resources.Load("Floor/Sea", typeof(GameObject))) as GameObject;
        GameObject map = new GameObject("Sea");
        Vector2 BornPoint = new Vector2(0, 0);

        for (int i = Convert.ToInt32(BornPoint.x); i < Convert.ToInt32(BornPoint.y) + rows; i++)
        {

            for (int j = Convert.ToInt32(BornPoint.y); j < Convert.ToInt32(BornPoint.y) + cols; j++)
            {            
                Common.FloorSpawn(GrassLand, i, j, map); 

            }

        }


    }

    //海
    [MenuItem("Assets/MapMaker/TestFloor")]
    public static void TestSpawn()
    {
        int TestRow = 500;
        int TestCol = 500;
        GrassLand = (Resources.Load("Floor/Grass", typeof(GameObject))) as GameObject;
        GameObject map = new GameObject("Test");
        Vector2 BornPoint = new Vector2(0, 0);

        for (int i = Convert.ToInt32(BornPoint.x); i < Convert.ToInt32(BornPoint.y) + TestRow; i++)
        {

            for (int j = Convert.ToInt32(BornPoint.y); j < Convert.ToInt32(BornPoint.y) + TestCol; j++)
            {
                Common.FloorSpawn(GrassLand, i, j, map);

            }

        }


    }


}
