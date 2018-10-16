using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeSystem : MonoBehaviour
{
    public static TimeSystem _instance;

    public SpriteRenderer dayRenderer;
    public SpriteRenderer torchNightRenderer;
    public Sprite[] nightSprites;

    private float time = 0;

    private int day;
    public int timePeriod;   //时间段  exc..凌晨。。上午

    public Text txtTime;

    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        time = 300;
        InvokeRepeating("GetCurrentTime", 0, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
       // time += 0.2f;  //时间加快，用于测试


        //GetCurrentTime();
        //print(time);
    }

    void GetCurrentTime()
    {
        //print("被调用了");

        day = (int)(time / 600.0f);
        timePeriod = (int)(time % 600.0f);

       // print(timePeriod);

        txtTime.text = "第" + (day+1).ToString() + "天 " + getPeriod();//+time.ToString("#0");
    }
    /// <summary>
    /// 

    /// </summary>
    /// <returns></returns>
    private string getPeriod()
    {
        //天的亮度 0~255   0:最亮
        //25s ~125s 凌晨            
        //125s ~200s 早上
        //200s ~275s 上午         
        //275s ~325s 中午         0
        //325s ~425s 下午
        //425s ~475s 晚上
        //475s ~500s 半夜
        //500s ~600s 深夜         255

        //255/600=0.425   中午 300s的时候最亮 

        //0~300s 天逐渐变亮
        if (timePeriod < 300)
        {
            dayRenderer.color = new Color(0, 0, 0, 1 - 1f / 300 * timePeriod);
        }
        //300s~600s 天逐渐变暗
        else
        {
            dayRenderer.color = new Color(0, 0, 0, 1f / 300 * (timePeriod-300));
        }

        #region 通过时间改变使用火把夜晚的Sprite   500-0-200
        //print(timePeriod);
        if (timePeriod < 50)
        {
            torchNightRenderer.sprite = nightSprites[0];
        }
        else if(timePeriod<100)
        {
            torchNightRenderer.sprite = nightSprites[1];
        }
        else if (timePeriod < 150 )
        {
            torchNightRenderer.sprite = nightSprites[2];
        }
        else if (timePeriod < 200)
        {
            torchNightRenderer.sprite = nightSprites[3];
        }
        if (timePeriod >= 500 && timePeriod < 600)
        {
            torchNightRenderer.sprite = nightSprites[1];
        }
        if(timePeriod>=200&&timePeriod<500&&torchNightRenderer.gameObject.activeInHierarchy)
        {
            //火把燃尽，到达白天
            torchNightRenderer.gameObject.SetActive(false);
            dayRenderer.gameObject.SetActive(true);
        }
        #endregion

        //判断时间段
        if (timePeriod > 0 && timePeriod <= 125)
        {
            return "凌晨";
        }    
        else if (timePeriod <= 200)
        {
            return "早上";
        }
        else if (timePeriod <= 275)
        {
            return "上午";
        }
        else if (timePeriod <= 325)
        {
            return "中午";
        }
        else if (timePeriod <= 425) return "下午";
        else if (timePeriod <= 475) return "晚上";
        else if (timePeriod <= 500) return "半夜";
        else if (timePeriod <= 600) return "深夜";
        else
        {
            print(" 没有此时间段,这是一个bug");
            return "";
        }

    }

}
