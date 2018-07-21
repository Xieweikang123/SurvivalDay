using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager _instance;

    public GameObject prefabCarrot;

    //地图行列数
    public int rows = 9;    
    public int cols = 9;

    public GameObject mapGressTiles;    //地图块
    public GameObject hillTile; //小山丘

    public GameObject[,] mapTiles = new GameObject[100, 100];

    private float rangeX=20;   //产生萝卜范围
    private float rangeY=20;   

    private float spawnCarrotTime = 3.0f;   //产生萝卜时间
    private int maxNumOfCarrot = 3;        //地图中萝卜最大存在量

    private float timer = 0;

    private void Awake()
    {
        _instance = this;
        InitMap();
    }


    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (timer >= spawnCarrotTime)
        {
            timer = 0;
            SpawnCarrot();
        }
	}

    //生成地图
    private void InitMap()
    {
        GameObject Map = new GameObject("Map");

        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                //如果是边界,生成小山丘
                if(i==0||j==0||i==rows-1||j==cols-1)
                {
                    Instantiate(hillTile, new Vector3(i, j, 0), Quaternion.identity, Map.transform);
                    continue;
                }

                //储存生存的地图块
               mapTiles[i,j]= Instantiate(mapGressTiles, new Vector3(i, j, 0), Quaternion.identity, Map.transform);
            }
        }

        //foreach(GameObject obj in mapTiles)
        //{
        //    print(obj);
        //}
    }


    //生成萝卜
    private void SpawnCarrot()
    {
        //当前场景中萝卜数量
        int currentNum = GameObject.FindGameObjectsWithTag("Crop").Length;
        if(currentNum>=maxNumOfCarrot)
        {
            //print("萝卜数量为最大");
            return;
        }
        float x = Random.Range(0, rangeX);
        float y = Random.Range(0, rangeY);
       /* GameObject obj = */Instantiate(prefabCarrot, new Vector3(x, y, 0), Quaternion.identity);
    }


}
