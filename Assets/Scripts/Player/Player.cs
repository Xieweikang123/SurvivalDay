using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 玩家类
/// </summary>
public class Player : MonoBehaviour {
  
    //角色ID
    public int PlayerID;
    //角色昵称
    public string PlayerName;
    //角色等级
    public int Level;
    //角色血量
    public int HP;
    //角色饱腹度
    public int Starvation;
    //口渴度
    public int Thirsty;
    //攻击力
    public int Attack;
    //防御值
    public int Defenses;

    //角色生成器
    public static void PlayerSpawn(Vector2 pos)
    {

        Player player = new Player();
        player.PlayerID = 001;
        player.Level = 1;
        player.HP = 100;
        player.Starvation = 100;
        player.Thirsty = 100;
        player.Attack = 5;
        player.Defenses = 5;
        GameObject playermodel = Resources.Load("Player/MainPlayer") as GameObject;
        Instantiate(playermodel, pos, Quaternion.identity);
    }

    //加载角色数据
    public static void LoadPlayerInfo()
    {


    }


    //保存角色数据
    public static void SavePlayerInfo()
    {

    }



  
}
