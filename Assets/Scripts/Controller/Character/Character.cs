using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProperty : MonoBehaviour
{

    protected int maxHealth; //最大血量
    protected int currentHealth = 100; //当前血量
    protected int maxHungry = 100; //最大饥饿度
    protected int currentHungry = 100;  //当前饥饿度
    protected int maxThirsty = 100;    //最大口渴值
    protected int currentThirsty = 100; //当前口渴值


}

//移动
public interface IMove
{
    float MoveSpeed
    {
        get;
        set;
    }

    void Move(Vector3 dir);

}
