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


    private int index = 0;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private float playPeriod = 1.0f; //两帧之间播放间隔
    private float timer = 0;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        //首次按下，先播放下一帧动画，瞬间响应玩家反馈
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            spriteRenderer.sprite = spritesMoveDown[++index];
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            spriteRenderer.sprite = spritesMoveUp[++index];
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spriteRenderer.sprite = spritesMoveLeft[++index];
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            spriteRenderer.sprite = spritesMoveRight[++index];
        }
        //如果键盘移动键抬起，则将动画置为0帧，使得玩家恢复至idle状态
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            index = 0;
            spriteRenderer.sprite = spritesMoveDown[index];
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            index = 0;
            spriteRenderer.sprite = spritesMoveUp[index];
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            index = 0;
            spriteRenderer.sprite = spritesMoveLeft[index];
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            index = 0;
            spriteRenderer.sprite = spritesMoveRight[index];
        }
        if (timer > playPeriod)
        {
            timer = 0;

            //TODO: 不一定是这个动画
            if (++index >= spritesMoveDown.Length-1)
                index = 0;

            print(index);

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                spriteRenderer.sprite = spritesMoveDown[++index];
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                spriteRenderer.sprite = spritesMoveUp[++index];
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                spriteRenderer.sprite = spritesMoveLeft[++index];
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                spriteRenderer.sprite = spritesMoveRight[++index];
            }
        
        }

       
    }
}
