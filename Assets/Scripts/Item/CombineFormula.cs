using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Item
{
    /// <summary>
    /// 合成配方
    /// </summary>
    public class CombineFormula
    {
        //合成公式ID
        public int FormulaID; 
        //合成类型
        public enum MaterialNeed
        {
          // 1种合成材料-4种合成材料 例： 1种：木材合成木地板； 2种：木材+铁锭合成铁剑； 
          OneMaterialsNeed=1,
          TwoMaterialsNeed=2,
          ThreeMaterialsNeed=3,
          FourMaterialsNeed=4,
          //装备+装备；装备升级（预留）
          EquipmentCombine=5,
          EquipmentUpdate=6
        }
        //每种所需材料ID
        public int FirstMaterialID;
        public int SecondMaterialID;
        public int ThirdMaterialID;
        public int FourthMaterialID;
        //每种材料所需数量
        public int FirstMaterialCounts;
        public int SecondMaterialCounts;
        public int ThirdMaterialCounts;
        public int FourthMaterialCounts;
        //获取合成公式
        public void GetFormula()
        {
            //FirstMaterialID=
            //SecondMaterialID=
            //ThirdMaterialID=
            //FourthMaterialID=
            //       FirstMaterialID=

        }



    }
}
