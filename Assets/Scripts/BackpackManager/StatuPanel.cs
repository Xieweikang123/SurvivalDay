using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatuPanel : PanelBase
{
    public string PlayerName;
    //UI
    public Text HP;
    public Text Water;
    public Text Hunger;
    
    #region 生命周期
    //初始化
    public override void Init(params object[] args)
    {
        base.Init(args);
        skinPath = "Statu_Skin";
        layer = PanelLayer.Statu;
    }

    public override void OnShowing()
    {
        base.OnShowing();
        Transform skinTrans = skin.transform;
        HP = skinTrans.Find("Txt_HP").GetComponent<Text>();
        Water = skinTrans.Find("Txt_Water").GetComponent<Text> ();
        Hunger = skinTrans.Find("Txt_Hunger").GetComponent<Text>();
    }
    #endregion
  
    

}