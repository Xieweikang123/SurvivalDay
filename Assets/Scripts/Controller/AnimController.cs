using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{

    [SerializeField]
    private Sprite[] spritesMoveDown;  //向下移动的动画帧
    [SerializeField]
    private Sprite[] spritesMoveUp;
    [SerializeField]
    private Sprite[] spritesMoveLeft;
    [SerializeField]
    private Sprite[] spritesMoveRight;

    private Sprite[] spritesMoveDir;    //移动动画数组，储存当前移动方向动画
    private int currentAnimIndex = 0;  //当前动画下标
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private float playPeriod = 1.0f; //两帧之间播放间隔
    private float timer = 0;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    //private void OnGUI()
    //{
    //    if (Input.anyKeyDown)
    //    {
    //        Event e = Event.current;
    //        if (e.isKey)
    //        {
    //            print("keyCode down:  " + e.keyCode);
    //        }
    //    }
    //}

    private void Update()
    {
        timer += Time.deltaTime;


        //首次按下，先播放下一帧动画，瞬间响应玩家反馈
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            spritesMoveDir = spritesMoveDown;
            timer = playPeriod;
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            spritesMoveDir = spritesMoveUp;
            timer = playPeriod;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spritesMoveDir = spritesMoveLeft;
            timer = playPeriod;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            spritesMoveDir = spritesMoveRight;
            timer = playPeriod;
        }
        //如果键盘移动键抬起，则将动画置为0帧，使得玩家恢复至idle状态
        if (Input.GetKeyUp(KeyCode.W)||Input.GetKeyUp(KeyCode.UpArrow)|| 
            Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)||
            Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)||
            Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            KeyLift();
        }

        if (timer >= playPeriod)
        {
            timer = 0;

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                ChangeMoveSprite(spritesMoveDown);
                return;
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                ChangeMoveSprite(spritesMoveUp);
                return;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                ChangeMoveSprite(spritesMoveLeft);
                return;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                ChangeMoveSprite(spritesMoveRight);
                return;
            }

        }
    }
    //移动方向键抬起
    private void KeyLift()
    {
        currentAnimIndex = 0;
        spriteRenderer.sprite = spritesMoveDir[currentAnimIndex];
    }

    //改变移动动画帧
    private void ChangeMoveSprite(Sprite[] spritesMoveDir)
    {
        
        //如果当前动画下标+1后，超过了动画数组的长度，则重置为0
        if (++currentAnimIndex == spritesMoveDir.Length)
            currentAnimIndex = 0;

        spriteRenderer.sprite = spritesMoveDir[currentAnimIndex];
    }
}
