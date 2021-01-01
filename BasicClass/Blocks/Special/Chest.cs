using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftCommandHelper.BasicClass.Blocks.Special
{
    class Chest:Block
    {
        #region Specials
        ChestSize type = ChestSize._undefined;
        int maxsize = 0;


        List<BasicClass.Items.Items> items = new List<Items.Items>();

        #endregion
        enum ChestSize
        {
            _undefined=0,//未定义
           _single=27,//单个箱子
           _double=54,//二连箱子
           _enderchest=27,//末影箱
           _backpack=36,//玩家背包
           _Shulker=27,//潜影盒
           _Bundle=64,//收纳袋
        }

        private void IntalizeChest(ChestSize sz)
        {
            type = sz;
        }
        private int GetItemsCount() => items.Count;

        private string GetItemsCommand()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in items)
            {
                sb.Append(item);
            }
            return sb.ToString();
        }

    }
}
