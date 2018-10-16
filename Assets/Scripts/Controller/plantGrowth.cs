using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantGrowth : MonoBehaviour {

    [SerializeField]
    private float lifeCycles;    //生长周期

    [SerializeField]
    private Sprite[] growthSprites; //生长图片

    private float spriteChangeInterval; //更换图片间隔
    private int currentSpriteIndex = 0; //当前图片下标

    private void Start()
    {
        //获取更换图片间隔
        spriteChangeInterval = lifeCycles / growthSprites.Length;

        InvokeRepeating("Grow", spriteChangeInterval, spriteChangeInterval);
    }

    private void Grow()
    {

        //print("Grow");

        //更改显示图片，并将当前图片下标加一
        GetComponent<SpriteRenderer>().sprite = growthSprites[++currentSpriteIndex];

        //如果更换到了最后一张图片，停止Invoke函数
        if (currentSpriteIndex == growthSprites.Length - 1)
        {
            CancelInvoke("Grow");
            //将Collider 激活
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }


}
