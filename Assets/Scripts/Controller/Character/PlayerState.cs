using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}


public class PlayerState : CharacterProperty,IMove
{

    public Slider sliderEnergy;

    public Text txtHealth;  //血量显示
    public Text txtHungry;
    public Text txtWater;

    public Direction direction = Direction.Up;    //玩家朝向

    public float moveSpeed = 3.0f;  //移动速度
   
    //滑动条
    public Slider sliderHealth;
    public Slider sliderHungry;
    public Slider sliderWater;

    private float reduceHealthPerSecond = 3f;   //每秒掉血
    private float reduceHungryPerSecond = 0.5f; //每秒掉饥饿值
    private float reduceWaterPerSecond = 0.8f;   //每秒失水量

    //  maxHealth = 100;
    private float currentHealth = 100;

    private float maxHungry = 100f;
    private float currentHungry = 100f;

    private float maxWater = 100f;
    private float currentWater = 100f;

    private float timer = 0;    //计时器

    private void LimitValue(ref float currentValue, float maxValue)
    {
        if (currentValue < 0)
            currentValue = 0;
        if (currentValue > maxValue)
            currentValue = maxValue;
    }
    #region  重构
    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
            LimitValue(ref currentHealth, maxHealth);

            StartCoroutine("LinerChangeHealth");
        }
    }

    public float CurrentHungry
    {
        get
        {
            return currentHungry;
        }

        set
        {
            currentHungry = value;
            LimitValue(ref currentHungry, maxHungry);

            StartCoroutine("LinerChangeHungry");
        }
    }

    public float CurrentWater
    {
        get
        {
            return currentWater;
        }

        set
        {
            currentWater = value;
            LimitValue(ref currentWater, maxWater);

            StartCoroutine("LinerChangeWater");
        }
    }

    public float MoveSpeed
    {
        get
        {
            throw new NotImplementedException();
        }

        set
        {
            throw new NotImplementedException();
        }
    }
    #endregion
    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        //按每个值100点计算，饥饿值每秒掉0.5，水分掉0.8，当水分或饥饿值不足时每秒掉3血
        if (timer >= 1.0f)
        {
            timer = 0;
            CurrentHungry -= reduceHungryPerSecond;
            CurrentWater -= reduceWaterPerSecond;

            //当饥饿值或者水分不足,减血
            if (CurrentHungry <= 5 || CurrentWater <= 5)
            {
                CurrentHealth -= reduceHealthPerSecond;
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            //CurrentHealth -= 10f;
            CurrentHungry -= 20f;
        }

    }

    #region 线性改变血量、饥饿值、水量
    IEnumerator LinerChangeHealth()
    {
        //误差在0.2f内
        if ( Mathf.Abs(sliderHealth.value-currentHealth)>0.2f)
        {
            if (sliderHealth.value < currentHealth)
                sliderHealth.value += 0.1f;
            else
                sliderHealth.value -= 0.1f;

            //text
            txtHealth.text = Mathf.Floor(sliderHealth.value).ToString();

            yield return new WaitForSeconds(0.01f);

            StartCoroutine("LinerChangeHealth");
        }
        else
        {
            StopCoroutine("LinerChangeHealth");
            //print("end");
        }
    }

    IEnumerator LinerChangeHungry()
    {

        if (Mathf.Abs(sliderHungry.value - CurrentHungry) > 0.2f )
        {
            if (sliderHungry.value < CurrentHungry)
                sliderHungry.value += 0.1f;
            else
                sliderHungry.value -= 0.1f;

            //text
            txtHungry.text = Mathf.Floor(sliderHungry.value).ToString();

            yield return new WaitForSeconds(0.01f);

            StartCoroutine("LinerChangeHungry");
        }
        else
        {
            StopCoroutine("LinerChangeHungry");
            //print("end");
        }
    }
    IEnumerator LinerChangeWater()
    {

        if (Mathf.Abs(sliderWater.value - CurrentWater) > 0.2f)
        {
            if (sliderWater.value < CurrentWater)
                sliderWater.value += 0.1f;
            else
                sliderWater.value -= 0.1f;
            
            //text
            txtWater.text = Mathf.Floor(sliderWater.value).ToString();

            yield return new WaitForSeconds(0.01f);

            StartCoroutine("LinerChangeWater");
        }
        else
        {
            StopCoroutine("LinerChangeWater");
            //print("end");
        }
    }
    #endregion

    //玩家朝向的下一个土块
    public Vector2 TowardPos()
    {
        Vector2 pos=Vector2.zero;

        switch (direction)
        {
            case Direction.Up: pos = new Vector2(Mathf.FloorToInt(transform.position.x+0.3f) , Mathf.FloorToInt(transform.position.y)+1); break;
            case Direction.Down: pos = new Vector2(Mathf.FloorToInt(transform.position.x+0.3f), Mathf.FloorToInt(transform.position.y)-1); break;
            case Direction.Left: pos = new Vector2(Mathf.FloorToInt(transform.position.x+0.3f) - 1, Mathf.FloorToInt(transform.position.y)); break;
            case Direction.Right: pos = new Vector2(Mathf.FloorToInt(transform.position.x+0.3f) + 1, Mathf.FloorToInt(transform.position.y)); break;  
        }
        return pos;
    }

    public void Move(Vector3 dir)
    {
        throw new NotImplementedException();
    }
}
