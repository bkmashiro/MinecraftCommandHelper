using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftCommandHelper.BasicClass.Blocks
{
    class Block
    {
        #region 基本属性

        private string block_namespace = "minecraft";
        string block_name = "";

        #endregion

        #region 方法

        #endregion
        /// <summary>
        /// 返还该方块的完全限定名称 例如 minecraft:stone  bakacraft:mashiro
        /// </summary>
        /// <returns></returns>
        string GetBlockFullName() => block_namespace+ ':' + block_name;

    }
}
